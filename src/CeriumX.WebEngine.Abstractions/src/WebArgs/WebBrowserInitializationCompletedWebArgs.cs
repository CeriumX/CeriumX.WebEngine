//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebBrowserInitializationCompletedWebArgs.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 14:56:20
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
/// WebBrowser初始化完成时事件参数类
/// </summary>
public sealed class WebBrowserInitializationCompletedWebArgs : EventArgs
{
    /// <summary>
    /// WebBrowser初始化完成时事件参数
    /// </summary>
    /// <param name="ex">初始化过程中出现的异常，如果初始化成功则为空。</param>
    public WebBrowserInitializationCompletedWebArgs(Exception? ex = null)
    {
        InitializationException = ex;
    }

    /// <summary>
    /// 是否成功完成初始化
    /// </summary>
    /// <remarks>true 成功，false 失败。</remarks>
    public bool IsSuccess => InitializationException == null;

    /// <summary>
    /// 初始化任务执行过程中抛出的异常，如果任务成功完成则为空。
    /// </summary>
    public Exception? InitializationException { get; }
}