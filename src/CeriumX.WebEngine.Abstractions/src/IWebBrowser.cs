//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IWebBrowser.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 14:53:15
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
/// 浏览器接口
/// </summary>
public interface IWebBrowser
{
    /// <summary>
    /// 当前进程ID
    /// </summary>
    uint CurrentProcessId { get; }

    /// <summary>
    /// 当前文档标题
    /// </summary>
    string CurrentTitle { get; }

    /// <summary>
    /// 当前URI链接地址
    /// </summary>
    string CurrentUri { get; }


    /// <summary>
    /// 将CSharp对象注册控制器添加到具有指定名称的JS对象
    /// </summary>
    /// <param name="rawController">CSharp对象注册控制器</param>
    void AddControllerToScript(IWebController rawController);

    /// <summary>
    /// 移除注册为指定名称的JS对象，及对应的CSharp对象注册控制器。
    /// </summary>
    /// <param name="controllerName">注册为JS对象的控制器名称</param>
    void RemoveControllerFromScript(string controllerName);


    /// <summary>
    /// 添加在全局对象被创建后立即运行的JavaScript脚本
    /// </summary>
    /// <remarks>在移除前将会一直存在并可以被执行</remarks>
    /// <param name="javaScript">要运行的JavaScript代码</param>
    /// <returns>将返回一个用作移除时使用ScriptId</returns>
    Task<string> AddScriptToExecuteOnDocumentCreatedAsync(string javaScript);

    /// <summary>
    /// 移除指定ScriptId的全局对象被创建后立即运行的JavaScript脚本
    /// </summary>
    /// <param name="scriptId">添加时所返回的ScriptId</param>
    void RemoveScriptToExecuteOnDocumentCreated(string scriptId);


    /// <summary>
    /// 添加一个提供虚拟网络访问的虚拟主机名和文件夹路径之间的映射
    /// </summary>
    /// <param name="virtualHostName">虚拟主机名</param>
    /// <param name="folderFullPath">要映射到虚拟主机名的文件夹路径</param>
    /// <param name="accessKind">虚拟主机资源访问级别</param>
    void AddVirtualHostNameToFolderMapping(string virtualHostName, string folderFullPath, VirtualResourceAccessKind accessKind);

    /// <summary>
    /// 移除添加的本地文件夹的虚拟主机名映射
    /// </summary>
    /// <param name="hostName">要从映射中移除的虚拟主机名</param>
    void RemoveVirtualHostNameToFolderMapping(string hostName);


    /// <summary>
    /// 捕捉当前浏览器正在显示的图像
    /// </summary>
    /// <remarks>可以理解为页面截图功能</remarks>
    /// <param name="imageFormat">浏览器捕捉图像格式</param>
    /// <param name="imageStream">写入二进制图像数据的流</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    Task CapturePreviewAsync(CapturePreviewImageFormat imageFormat, Stream imageStream);

    /// <summary>
    /// 运行指定JavaScript脚本，或调用相关函数、对象等。
    /// </summary>
    /// <param name="javaScript">要运行的JavaScript脚本</param>
    /// <returns>一个JSON编码的字符串，表示运行所提供的JavaScript的结果。</returns>
    Task<string> ExecuteScriptAsync(string javaScript);

    /// <summary>
    /// 将WebView导航到导航历史中的前一个页面
    /// </summary>
    void GoBack();

    /// <summary>
    /// 将WebView导航到导航历史中的下一个页面
    /// </summary>
    void GoForward();

    /// <summary>
    /// 导航到指定URI链接地址
    /// </summary>
    /// <param name="uri">要导航的URI链接地址</param>
    void Navigate(string uri);

    /// <summary>
    /// 导航到指定HTML文档
    /// </summary>
    /// <param name="htmlContent">需要导航的HTML文档</param>
    void NavigateToString(string htmlContent);


    /// <summary>
    /// 打开开发者工具窗口
    /// </summary>
    void OpenDevToolsWindow();

    /// <summary>
    /// 打开任务管理器窗口
    /// </summary>
    void OpenTaskManagerWindow();

    /// <summary>
    /// 投递指定JSON格式字符串到当前浏览器文档中
    /// </summary>
    /// <param name="webMessageAsJson">需要投递的JSON格式字符串</param>
    void PostWebMessageAsJson(string webMessageAsJson);

    /// <summary>
    /// 投递指定字符串格式内容到当前浏览器文档中
    /// </summary>
    /// <param name="webMessageAsString">需要投递的字符串格式内容</param>
    void PostWebMessageAsString(string webMessageAsString);


    /// <summary>
    /// 重新加载当前页面
    /// </summary>
    void Reload();

    /// <summary>
    /// 取消休眠状态，并同时恢复页面上的活动。
    /// </summary>
    void Resume();

    /// <summary>
    /// 停止所有的导航和待处理的资源获取
    /// </summary>
    void Stop();

    /// <summary>
    /// 尝试休眠当前浏览器，以减少内存消耗。
    /// </summary>
    /// <remarks>当还有脚本正在运行时，将会等待完成后执行休眠。</remarks>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    Task<bool> TrySuspendAsync();


    /// <summary>
    /// 全屏变更事件，当页面进入全屏或离开全屏时触发此事件。
    /// </summary>
    event EventHandler<object> OnFullScreenChanged;

    /// <summary>
    /// 当初始的HTML文档被解析后触发此事件
    /// </summary>
    event EventHandler<ulong> OnDOMContentLoaded;

    /// <summary>
    /// 导航完成时触发此事件
    /// </summary>
    event EventHandler<NavigationCompletedWebArgs> OnNavigationCompleted;

    /// <summary>
    /// Web消息接收事件，当调用window.chrome.webview.postMessage时触发此事件。
    /// </summary>
    event EventHandler<WebMessageReceivedWebArgs> OnWebMessageReceived;

    /// <summary>
    /// 窗口关闭事件，当调用window.close()运行后触发此事件。
    /// </summary>
    event EventHandler<object> OnWindowCloseRequested;
}