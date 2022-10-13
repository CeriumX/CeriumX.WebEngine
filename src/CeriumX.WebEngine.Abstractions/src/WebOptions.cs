//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebOptions.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 13:46:54
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
/// WebEngine创建选项(参数)类
/// </summary>
public sealed class WebOptions
{
    /// <summary>
    /// WebEngine创建选项(参数)
    /// </summary>
    /// <param name="initialUrl">初始的超链接地址(默认显示空白页)</param>
    public WebOptions(string? initialUrl = null) => InitialUrl = initialUrl;


    /// <summary>
    /// 初始的超链接地址
    /// </summary>
    /// <remarks>默认显示空白页</remarks>
    public string? InitialUrl { get; set; }

    /// <summary>
    /// 用户缓存数据存放目录(默认应用程序根目录)
    /// </summary>
    /// <remarks>
    /// 如果设置了此值，将会为当前创建的浏览器窗口，使用独立的用户缓存数据存放目录；如果不设置将使用默认的。
    /// <para>必须为绝对路径</para>
    /// </remarks>
    public string? UserDataFolder { get; set; } = null;

    /// <summary>
    /// 是否使用新窗口来打开弹出窗口
    /// </summary>
    /// <remarks>true 使用新窗口，false 不使用，默认false。</remarks>
    public bool UseNewWindowToOpenPopup { get; set; } = false;

    /// <summary>
    /// 是否允许Web内容访问主机对象
    /// </summary>
    /// <remarks>true 允许，false 不允许，默认true。</remarks>
    public bool AreHostObjectsAllowed { get; set; } = true;


    /// <summary>
    /// 创建WebEngine创建选项(参数)
    /// </summary>
    /// <param name="initialUrl">初始的超链接地址(默认显示空白页)</param>
    /// <returns>WebEngine创建选项(参数)</returns>
    public static WebOptions Create(string? initialUrl = null) => new(initialUrl);
}