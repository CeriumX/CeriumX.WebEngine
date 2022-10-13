//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebWindow2WinForm.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 16:06:41
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
/// 浏览器窗口
/// </summary>
/// <remarks>控件类型必须为 System.Windows.Forms.Control 或者 System.Windows.UIElement 两者之一</remarks>
/// <typeparam name="TControlType">用于作为浏览器控件的承载控件类型</typeparam>
internal sealed class WebWindow2WinForm<TControlType> : IWebWindow<TControlType>
        where TControlType : class
{
    private readonly CoreWebView2Environment _environment;
    private readonly WebOptions _options;
    private readonly Microsoft.Web.WebView2.WinForms.WebView2 _webView;
    private readonly WebContext _context;


    /// <summary>
    /// 浏览器窗口
    /// </summary>
    /// <param name="context">内部的Web交互上下文</param>
    /// <param name="environment">WebView运行环境</param>
    /// <param name="options">WebEngine创建选项(参数)</param>
    public WebWindow2WinForm(WebContext context, CoreWebView2Environment? environment, WebOptions options)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        _context = context;
        _environment = environment;
        _options = options;

        _webView = new();
        // 在控件未创建时执行初始化将会失败，或者一直处于等待状态。
        _webView.HandleCreated += WebView2_HandleCreated;
        BrowserControl = _webView as TControlType;

        _context.Logger.Info($"成功创建适用于 WinForm 的浏览器窗口。");
    }


    #region 成员方法

    /// <summary>
    /// 窗口句柄创建完成时事件
    /// </summary>
    /// <param name="sender">传递对象</param>
    /// <param name="e">传递事件</param>
    private async void WebView2_HandleCreated(object? sender, EventArgs e)
    {
        // WebView2初始化完成时事件
        _webView.CoreWebView2InitializationCompleted += (sender, e) =>
        {
            _context.Logger.Info($"浏览器与底层核心对象初始化完成，进程ID：{_webView.CoreWebView2.BrowserProcessId}。");

            Browser = new WebBrowser(_context, _webView.CoreWebView2);

            OnWebBrowserInitializationCompleted?.Invoke(sender, new WebBrowserInitializationCompletedWebArgs(e.InitializationException));
        };

        // 导航完成时事件
        _webView.NavigationCompleted += (sender, e) =>
        {
            NavigationCompletedWebArgs args = new(e.IsSuccess, e.NavigationId, (uint)e.WebErrorStatus);
            OnNavigationCompleted?.Invoke(sender, args);
        };

        // 缩放系数属性变化时事件
        _webView.ZoomFactorChanged += (sender, e) => ZoomFactorChanged?.Invoke(sender, e);


        _context.Logger.Debug($"执行浏览器底层的显式初始化操作。");

        // 调用 EnsureCoreWebView2Async 方法显式初始化底层
        await _webView.EnsureCoreWebView2Async(_environment);

        _context.Logger.Debug($"完成浏览器底层的显式初始化操作。");


        _context.Logger.Debug($"执行浏览器基本设置操作。");

        // 基本设置
        WebBrowserSettings.CallBasedSetting(_webView.CoreWebView2, _options);

        // 是否使用新窗口来打开弹出窗口
        if (!_options.UseNewWindowToOpenPopup)
        {
            _webView.CoreWebView2.NewWindowRequested += (sender, e) =>
            {
                e.Handled = true;
                _webView.CoreWebView2.Navigate(e.Uri);
            };
        }

        // 导航到起始页面
        string urlString = _options.InitialUrl is null ? "about:blank" : _options.InitialUrl;
        _webView.CoreWebView2.Navigate(urlString);
    }

    #endregion

    #region 接口实现[IWebWindow]

    /// <summary>
    /// 用于承载浏览器窗口的控件
    /// </summary>
    public TControlType? BrowserControl { get; }

    /// <summary>
    /// 浏览器
    /// </summary>
    public IWebBrowser? Browser { get; private set; }

    /// <summary>
    /// 默认的背景色
    /// </summary>
    public Color DefaultBackgroundColor
    {
        get => _webView.DefaultBackgroundColor;
        set
        {
            _webView.DefaultBackgroundColor = value;
        }
    }

    /// <summary>
    /// 缩放系数（默认1.0）
    /// </summary>
    /// <remarks>用于设置页面的缩放系数，数值区间为0-1之间。</remarks>
    public double ZoomFactor
    {
        get => _webView.ZoomFactor;
        set
        {
            _webView.ZoomFactor = value;
        }
    }


    /// <summary>
    /// WebBrowser初始化完成时事件
    /// </summary>
    public event EventHandler<WebBrowserInitializationCompletedWebArgs>? OnWebBrowserInitializationCompleted;

    /// <summary>
    /// 导航操作完成时事件
    /// </summary>
    public event EventHandler<NavigationCompletedWebArgs>? OnNavigationCompleted;

    /// <summary>
    /// 缩放系数属性改变事件
    /// </summary>
    public event EventHandler<EventArgs>? ZoomFactorChanged;


    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        _context.Logger.Info($"释放浏览器窗口资源[进程: {Browser?.CurrentProcessId}]。");

        _webView?.Dispose();
    }

    #endregion

}