//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebWindowFactoryProvider.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 16:20:00
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
/// 浏览器窗口创建工厂提供者
/// </summary>
public static class WebWindowFactoryProvider
{
    /// <summary>
    /// 创建一个浏览器窗口创建工厂
    /// </summary>
    /// <remarks>环境目录和用户数据目录，建议使用绝对路径，如果为相对路径，将以当前程序目录作为父目录，并进行组合。</remarks>
    /// <param name="browserExecutableFolder">运行时环境所在目录</param>
    /// <param name="userDataFolder">用户数据目录，如果为空则默认存储在运行时的UserData目录下。</param>
    /// <param name="nlogRulePrefixName">NLog配置规则名前缀，如：Monica.*，传递 Monica 即可。</param>
    /// <returns>浏览器窗口创建工厂</returns>
    public static IWebWindowFactory CreateWebWindowFactory(string browserExecutableFolder, string? userDataFolder = null, string? nlogRulePrefixName = null)
    {
        return new WebWindowFactory(browserExecutableFolder, userDataFolder, nlogRulePrefixName);
    }
}