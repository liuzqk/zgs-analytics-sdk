using UnityEngine;

namespace ZGS.Analytics
{
    public static class AnalyticsBootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void AutoInitialize()
        {
            var config = Resources.Load<ZGSAnalyticsConfig>("ZGSAnalyticsConfig");
            if (config == null)
            {
                AnalyticsLog.LogWarning("[ZGS.Analytics] Config not found in Resources/ZGSAnalyticsConfig. Analytics disabled.");
                return;
            }

            if (!config.EnableAnalytics) return;

            // ZGS Server Provider
            if (!string.IsNullOrEmpty(config.zgsServerUrl))
            {
                var zgsProvider = new ZGSServerProvider(config.zgsServerUrl, config.zgsSecret, config.appId);
                AnalyticsService.AddProvider(zgsProvider);
                SessionManager.Instance.StartSession(zgsProvider);
            }

            if (Application.isEditor && config.debugMode)
            {
                AnalyticsService.AddProvider(new DebugProvider());
            }

            // 初始化 CrashReporter (订阅 Unity 日志)
            CrashReporter.Initialize();

            // 配置附件上传（如果有设置）
            if (!string.IsNullOrEmpty(config.attachmentUploadUrl))
            {
                AnalyticsConfig.AttachmentUploadUrl = config.attachmentUploadUrl;
                AnalyticsConfig.AttachmentUploadSecret = config.attachmentUploadSecret;
                CrashReporter.RegisterAttachmentUploader(new ZipAttachmentUploader());
            }

            // 初始化所有 Provider (会触发 SessionInfo.Initialize)
            AnalyticsService.Initialize();

            // 监听退出事件以释放资源
            Application.quitting += AnalyticsService.Shutdown;
        }
    }
}
