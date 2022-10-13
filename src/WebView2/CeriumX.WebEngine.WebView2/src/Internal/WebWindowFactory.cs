//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebWindowFactory.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 16:05:49
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
/// 浏览器窗口创建工厂
/// </summary>
internal sealed class WebWindowFactory : IWebWindowFactory
{
    private int _envInitialized = 0;
    private readonly string _browserExecutableFolder;
    private readonly string _userDataFolder;
    private readonly CoreWebView2EnvironmentOptions _environmentOptions;
    private CoreWebView2Environment? _environmentRuntime;
    private readonly WebContext _context;


    /// <summary>
    /// 浏览器窗口创建工厂
    /// </summary>
    /// <remarks>环境目录和用户数据目录，建议使用绝对路径，如果为相对路径，将以当前程序目录作为父目录，并进行组合。</remarks>
    /// <param name="browserExecutableFolder">运行时环境所在目录</param>
    /// <param name="userDataFolder">用户数据目录，如果为空则默认存储在运行时的UserData目录下。</param>
    /// <param name="nlogRulePrefixName">NLog配置规则名前缀，如：Monica.*，传递 Monica 即可。</param>
    public WebWindowFactory(
        string browserExecutableFolder,
        string? userDataFolder = null,
        string? nlogRulePrefixName = null)
    {
        string ruleName = nlogRulePrefixName is null ? "WebView2" : nlogRulePrefixName;
        _context = new(ruleName);

        _context.Logger.Info($"开始初始化浏览器窗口创建工厂。");

        _environmentOptions = new(additionalBrowserArguments: null,
                                  language: "zh-CN",
                                  targetCompatibleBrowserVersion: null,
                                  allowSingleSignOnUsingOSPrimaryAccount: false);

        _browserExecutableFolder = System.IO.Path.GetFullPath(browserExecutableFolder);

        if (string.IsNullOrWhiteSpace(userDataFolder))
        {
            _userDataFolder = System.IO.Path.Combine(_browserExecutableFolder, "UserData");
        }
        else
        {
            _userDataFolder = System.IO.Path.GetFullPath(userDataFolder);
        }

        _context.Logger.Info($"浏览器窗口创建工厂初始化完成。");
    }


    #region 接口实现[IWebWindowFactory]

    /// <summary>
    /// 初始化运行环境
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task InitializeEnvironmentAsync()
    {
        if (Interlocked.Exchange(ref _envInitialized, 1) == 1) return;

        _context.Logger.Info($"开始初始化浏览器运行环境。");

        _environmentRuntime = await CoreWebView2Environment.CreateAsync(browserExecutableFolder: _browserExecutableFolder,
                                                                        userDataFolder: _userDataFolder,
                                                                        options: _environmentOptions)
                                                           .ConfigureAwait(false);

        _context.Logger.Info($"浏览器运行环境初始化完成，当前版本号为：{_environmentRuntime.BrowserVersionString}。");
    }

    /// <summary>
    /// 创建一个浏览器窗口
    /// </summary>
    /// <remarks>控件类型必须为 System.Windows.Forms.Control 或者 System.Windows.UIElement 两者之一</remarks>
    /// <typeparam name="TControlType">用于作为浏览器控件的承载控件类型</typeparam>
    /// <param name="option">WebEngine创建选项(参数)</param>
    /// <returns>浏览器窗口</returns>
    public async Task<IWebWindow<TControlType>> CreateAsync<TControlType>(WebOptions option)
        where TControlType : class
    {
        _context.Logger.Info($"浏览器窗口创建操作被执行。");

        await Task.Delay(0).ConfigureAwait(false);

        _context.Logger.Debug($"浏览器窗口创建选项：默认链接: {option.InitialUrl}，用户缓存目录: {option.UserDataFolder}，是否允许独立弹出窗口: {option.UseNewWindowToOpenPopup}，是否允许与主机交互: {option.AreHostObjectsAllowed}。");
        _context.Logger.Debug($"当前创建的浏览器控件类型为：{typeof(TControlType)}");

        // WinForm
        if (ReferenceEquals(typeof(TControlType), typeof(Control)))
        {
            return new WebWindow2WinForm<TControlType>(_context, _environmentRuntime, option);
        }

        // WPF
        if (ReferenceEquals(typeof(TControlType), typeof(System.Windows.UIElement)))
        {
            return new WebWindow2WPF<TControlType>(_context, _environmentRuntime, option);
        }

        string errorMessage = "对不起！泛型对象必须是 System.Windows.Forms.Control (WinForm) 或者 System.Windows.UIElement (WPF) 两者之一。";
        _context.Logger.Error(errorMessage);

        throw new NotSupportedException(errorMessage);
    }


    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        NLog.LogManager.Shutdown();
    }

    #endregion

}