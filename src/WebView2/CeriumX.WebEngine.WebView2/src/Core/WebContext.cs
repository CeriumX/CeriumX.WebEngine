//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebContext.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 16:03:02
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
namespace CeriumX.WebEngine.WebView2;

/// <summary>
/// 内部的Web交互上下文
/// </summary>
internal sealed class WebContext
{
    /// <summary>
    /// 内部的Web交互上下文
    /// </summary>
    /// <param name="nlogRulePrefixName">NLog配置规则名前缀，如：Monica.*，传递 Monica 即可。</param>
    public WebContext(string nlogRulePrefixName)
    {
        Logger = NLog.LogManager.GetLogger($"{nlogRulePrefixName}.Cockroach.{Guid.NewGuid().GetHashCode()}");
        Logger.Info("实例化浏览器上下文对象。");
    }


    /// <summary>
    /// 日志记录器
    /// </summary>
    public NLog.Logger Logger { get; }
}