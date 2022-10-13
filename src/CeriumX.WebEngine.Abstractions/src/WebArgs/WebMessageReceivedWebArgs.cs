//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebMessageReceivedWebArgs.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 14:57:03
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace CeriumX.WebEngine.Abstractions;

/// <summary>
/// Web消息接收处理事件参数类
/// </summary>
public sealed class WebMessageReceivedWebArgs : EventArgs
{
    /// <summary>
    /// 当前消息来源的URI链接地址
    /// </summary>
    public string? Uri { get; set; }

    /// <summary>
    /// 将收到的消息转换为JSON字符串
    /// </summary>
    public string? MessageAsJson { get; set; }

    /// <summary>
    /// 尝试将收到的消息转换为字符串，如果失败则返回null值。
    /// </summary>
    /// <remarks>当确定收到的消息为字符串内容时</remarks>
    public Func<string?>? TryGetMessageAsString { get; set; }
}