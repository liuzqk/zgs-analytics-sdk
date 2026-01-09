namespace ZGS.Analytics
{
    /// <summary>
    /// Analytics SDK 配置
    /// </summary>
    public static class AnalyticsConfig
    {
        /// <summary>是否启用 Debug 日志</summary>
        public static bool DebugMode { get; set; } = true;

        /// <summary>附件上传 URL</summary>
        public static string AttachmentUploadUrl { get; set; }

        /// <summary>上传认证密钥</summary>
        public static string AttachmentUploadSecret { get; set; }

        /// <summary>是否已配置附件上传</summary>
        public static bool IsAttachmentUploadConfigured =>
            !string.IsNullOrEmpty(AttachmentUploadUrl) && !string.IsNullOrEmpty(AttachmentUploadSecret);
    }
}
