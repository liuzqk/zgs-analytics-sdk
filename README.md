# ZGS Analytics SDK

ZeroGameStudio 游戏分析 SDK，用于 Unity 项目数据采集。

## 安装

在 Unity 项目的 `Packages/manifest.json` 中添加：

```json
{
  "dependencies": {
    "com.zerogamestudio.analytics": "https://github.com/liuzqk/zgs-analytics-sdk.git"
  }
}
```

## 配置

1. 创建配置文件：`Create > ZGS > Analytics Config`
2. 放到 `Resources/ZGSAnalyticsConfig.asset`
3. 填写服务器地址和密钥

## 使用

```csharp
using ZGS.Analytics;

// 记录事件
Analytics.LogEvent("level_complete", new Dictionary<string, object>
{
    ["level_id"] = "boss_001",
    ["time_spent"] = 120
});

// 记录错误
Analytics.LogError("Exception message", stackTrace);

// 屏幕追踪
Analytics.TrackScreen("MainMenu");
```

## 自动采集字段

每个事件自动附带：
- `app_id` - 游戏标识
- `is_editor` - 是否编辑器运行
- `app_version` - 游戏版本
- `platform` - 运行平台
- `user_id` - 设备唯一 ID
- `session_id` - 会话 ID

## Dashboard

数据可在 ZeroGameStudio Analytics Dashboard 查看。
