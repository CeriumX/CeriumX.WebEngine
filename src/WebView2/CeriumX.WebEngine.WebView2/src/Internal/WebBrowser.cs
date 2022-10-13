//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebBrowser.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 16:05:18
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.IO;

namespace CeriumX.WebEngine.WebView2;

/// <summary>
/// 浏览器
/// </summary>
internal sealed class WebBrowser : IWebBrowser
{
    private readonly WebContext _context;
    private readonly CoreWebView2 _coreWebView2;


    /// <summary>
    /// 浏览器
    /// </summary>
    /// <param name="context">内部的Web交互上下文</param>
    /// <param name="core">WebView2控件底层核心对象</param>
    public WebBrowser(WebContext context, CoreWebView2 core)
    {
        _context = context;
        _coreWebView2 = core;

        RegionInternalEvent();
    }


    #region 成员方法

    /// <summary>
    /// 注册内部事件
    /// </summary>
    private void RegionInternalEvent()
    {
        _context.Logger.Info($"初始化浏览器对象[PID:{CurrentProcessId}]，执行基本事件绑定操作。");

        // 全屏变更事件
        _coreWebView2.ContainsFullScreenElementChanged += (sender, e) =>
        {
            OnFullScreenChanged?.Invoke(sender, e);
        };

        // 当初始的HTML文档被解析后事件
        _coreWebView2.DOMContentLoaded += (sender, e) =>
        {
            OnDOMContentLoaded?.Invoke(sender, e.NavigationId);
        };

        // 导航完成时事件
        _coreWebView2.NavigationCompleted += (sender, e) =>
        {
            NavigationCompletedWebArgs args = new(e.IsSuccess, e.NavigationId, (uint)e.WebErrorStatus);
            OnNavigationCompleted?.Invoke(sender, args);
        };

        // Web消息接收事件
        _coreWebView2.WebMessageReceived += (sender, e) =>
        {
            OnWebMessageReceived?.Invoke(sender, new WebMessageReceivedWebArgs()
            {
                Uri = e.Source,
                MessageAsJson = e.WebMessageAsJson,
                TryGetMessageAsString = () => e.TryGetWebMessageAsString()
            });
        };

        // 窗口关闭事件
        _coreWebView2.WindowCloseRequested += (sender, e) =>
        {
            OnWindowCloseRequested?.Invoke(sender, e);
        };
    }

    #endregion

    #region 接口实现[IWebBrowser]

    /// <summary>
    /// 当前进程ID
    /// </summary>
    public uint CurrentProcessId => _coreWebView2.BrowserProcessId;

    /// <summary>
    /// 当前文档标题
    /// </summary>
    public string CurrentTitle => _coreWebView2.DocumentTitle;

    /// <summary>
    /// 当前URI链接地址
    /// </summary>
    public string CurrentUri => _coreWebView2.Source;


    /// <summary>
    /// 将CSharp对象注册控制器添加到具有指定名称的JS对象
    /// </summary>
    /// <param name="rawController">CSharp对象注册控制器</param>
    public void AddControllerToScript(IWebController rawController)
    {
        _context.Logger.Debug($"添加可交互控制器对象[PID:{CurrentProcessId}]，控制器名称：{rawController.ControllerName}。");

        _coreWebView2.AddHostObjectToScript(rawController.ControllerName, rawController);
    }

    /// <summary>
    /// 移除注册为指定名称的JS对象，及对应的CSharp对象注册控制器。
    /// </summary>
    /// <param name="controllerName">注册为JS对象的控制器名称</param>
    public void RemoveControllerFromScript(string controllerName)
    {
        _context.Logger.Debug($"移除可交互控制器对象[PID:{CurrentProcessId}]，控制器名称：{controllerName}。");

        _coreWebView2.RemoveHostObjectFromScript(controllerName);
    }


    /// <summary>
    /// 添加在全局对象被创建后立即运行的JavaScript脚本
    /// </summary>
    /// <remarks>在移除前将会一直存在并可以被执行</remarks>
    /// <param name="javaScript">要运行的JavaScript代码</param>
    /// <returns>将返回一个用作移除时使用ScriptId</returns>
    public async Task<string> AddScriptToExecuteOnDocumentCreatedAsync(string javaScript)
    {
        string scriptId = await _coreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(javaScript).ConfigureAwait(false);

        _context.Logger.Debug($"添加DOM创建后执行的全局脚本：{javaScript}，脚本ID：{scriptId}，[PID:{CurrentProcessId}]。");

        return scriptId;
    }

    /// <summary>
    /// 移除指定ScriptId的全局对象被创建后立即运行的JavaScript脚本
    /// </summary>
    /// <param name="scriptId">添加时所返回的ScriptId</param>
    public void RemoveScriptToExecuteOnDocumentCreated(string scriptId)
    {
        _context.Logger.Debug($"移除DOM创建后执行的全局脚本，脚本ID：{scriptId}，[PID:{CurrentProcessId}]。");

        _coreWebView2.RemoveScriptToExecuteOnDocumentCreated(scriptId);
    }


    /// <summary>
    /// 添加一个提供虚拟网络访问的虚拟主机名和文件夹路径之间的映射
    /// </summary>
    /// <param name="virtualHostName">虚拟主机名</param>
    /// <param name="folderFullPath">要映射到虚拟主机名的文件夹路径</param>
    /// <param name="accessKind">虚拟主机资源访问级别</param>
    public void AddVirtualHostNameToFolderMapping(string virtualHostName, string folderFullPath, VirtualResourceAccessKind accessKind)
    {
        if (Enum.TryParse($"{accessKind}", out CoreWebView2HostResourceAccessKind innerAccessKind))
        {
            _context.Logger.Debug($"添加虚拟目录映射[PID:{CurrentProcessId}]：{virtualHostName}");

            _coreWebView2.SetVirtualHostNameToFolderMapping(virtualHostName, folderFullPath, innerAccessKind);
        }
    }

    /// <summary>
    /// 移除添加的本地文件夹的虚拟主机名映射
    /// </summary>
    /// <param name="hostName">要从映射中移除的虚拟主机名</param>
    public void RemoveVirtualHostNameToFolderMapping(string hostName)
    {
        _context.Logger.Debug($"移除虚拟目录映射[PID:{CurrentProcessId}]：{hostName}");

        _coreWebView2.ClearVirtualHostNameToFolderMapping(hostName);
    }


    /// <summary>
    /// 捕捉当前浏览器正在显示的图像
    /// </summary>
    /// <remarks>可以理解为页面截图功能</remarks>
    /// <param name="imageFormat">浏览器捕捉图像格式</param>
    /// <param name="imageStream">写入二进制图像数据的流</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task CapturePreviewAsync(CapturePreviewImageFormat imageFormat, Stream imageStream)
    {
        _context.Logger.Debug($"捕捉当前浏览器正在显示的图像[PID:{CurrentProcessId}]。");

        if (Enum.TryParse($"{imageFormat}", out CoreWebView2CapturePreviewImageFormat innerImageFormat))
        {
            await _coreWebView2.CapturePreviewAsync(innerImageFormat, imageStream).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// 运行指定JavaScript脚本，或调用相关函数、对象等。
    /// </summary>
    /// <param name="javaScript">要运行的JavaScript脚本</param>
    /// <returns>一个JSON编码的字符串，表示运行所提供的JavaScript的结果。</returns>
    public async Task<string> ExecuteScriptAsync(string javaScript)
    {
        string result = await _coreWebView2.ExecuteScriptAsync(javaScript).ConfigureAwait(false);

        _context.Logger.Debug($"运行指定JavaScript脚本：{javaScript}，运行结果：{result}，[PID:{CurrentProcessId}]。");

        return result;
    }

    /// <summary>
    /// 将WebView导航到导航历史中的前一个页面
    /// </summary>
    public void GoBack()
    {
        if (_coreWebView2.CanGoBack)
        {
            _coreWebView2.GoBack();
        }
    }

    /// <summary>
    /// 将WebView导航到导航历史中的下一个页面
    /// </summary>
    public void GoForward()
    {
        if (_coreWebView2.CanGoForward)
        {
            _coreWebView2.GoForward();
        }
    }

    /// <summary>
    /// 导航到指定URI链接地址
    /// </summary>
    /// <param name="uri">要导航的URI链接地址</param>
    public void Navigate(string uri)
    {
        _context.Logger.Debug($"导航到指定URI链接地址[PID:{CurrentProcessId}]：{uri}");

        _coreWebView2.Navigate(uri);
    }

    /// <summary>
    /// 导航到指定HTML文档
    /// </summary>
    /// <param name="htmlContent">需要导航的HTML文档</param>
    public void NavigateToString(string htmlContent)
    {
        _context.Logger.Debug($"导航到指定HTML文档[PID:{CurrentProcessId}]：{htmlContent}");

        _coreWebView2.NavigateToString(htmlContent);
    }


    /// <summary>
    /// 打开开发者工具窗口
    /// </summary>
    public void OpenDevToolsWindow() => _coreWebView2.OpenDevToolsWindow();

    /// <summary>
    /// 打开任务管理器窗口
    /// </summary>
    public void OpenTaskManagerWindow() => _coreWebView2.OpenTaskManagerWindow();

    /// <summary>
    /// 投递指定JSON格式字符串到当前浏览器文档中
    /// </summary>
    /// <param name="webMessageAsJson">需要投递的JSON格式字符串</param>
    public void PostWebMessageAsJson(string webMessageAsJson)
    {
        _context.Logger.Debug($"JSON消息投递[PID:{CurrentProcessId}]：{webMessageAsJson}");

        _coreWebView2.PostWebMessageAsJson(webMessageAsJson);
    }

    /// <summary>
    /// 投递指定字符串格式内容到当前浏览器文档中
    /// </summary>
    /// <param name="webMessageAsString">需要投递的字符串格式内容</param>
    public void PostWebMessageAsString(string webMessageAsString)
    {
        _context.Logger.Debug($"字符串消息投递[PID:{CurrentProcessId}]：{webMessageAsString}");

        _coreWebView2.PostWebMessageAsString(webMessageAsString);
    }


    /// <summary>
    /// 重新加载当前页面
    /// </summary>
    public void Reload() => _coreWebView2.Reload();

    /// <summary>
    /// 取消休眠状态，并同时恢复页面上的活动。
    /// </summary>
    public void Resume() => _coreWebView2.Resume();

    /// <summary>
    /// 停止所有的导航和待处理的资源获取
    /// </summary>
    public void Stop() => _coreWebView2.Stop();

    /// <summary>
    /// 尝试休眠当前浏览器，以减少内存消耗。
    /// </summary>
    /// <remarks>当还有脚本正在运行时，将会等待完成后执行休眠。</remarks>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task<bool> TrySuspendAsync()
    {
        _context.Logger.Debug($"尝试休眠当前浏览器[PID:{CurrentProcessId}]，以减少内存消耗。");

        return await _coreWebView2.TrySuspendAsync().ConfigureAwait(false);
    }


    /// <summary>
    /// 全屏变更事件，当页面进入全屏或离开全屏时触发此事件。
    /// </summary>
    public event EventHandler<object>? OnFullScreenChanged;

    /// <summary>
    /// 当初始的HTML文档被解析后触发此事件
    /// </summary>
    public event EventHandler<ulong>? OnDOMContentLoaded;

    /// <summary>
    /// 导航完成时触发此事件
    /// </summary>
    public event EventHandler<NavigationCompletedWebArgs>? OnNavigationCompleted;

    /// <summary>
    /// Web消息接收事件，当调用window.chrome.webview.postMessage时触发此事件。
    /// </summary>
    public event EventHandler<WebMessageReceivedWebArgs>? OnWebMessageReceived;

    /// <summary>
    /// 窗口关闭事件，当调用window.close()运行后触发此事件。
    /// </summary>
    public event EventHandler<object>? OnWindowCloseRequested;

    #endregion

}