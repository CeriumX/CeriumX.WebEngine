//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebBrowserSettings.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 15:32:13
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
/// WebBrowser基础的设置
/// </summary>
internal static class WebBrowserSettings
{
    /// <summary>
    /// 调用WebBrowser基础的设置
    /// </summary>
    /// <param name="core">WebView2控件底层核心对象</param>
    /// <param name="options">WebEngine创建选项(参数)</param>
    internal static void CallBasedSetting(CoreWebView2 core, WebOptions options)
    {
        // 禁用所有访问网络浏览器特定功能的加速器按键
        core.Settings.AreBrowserAcceleratorKeysEnabled = false;

        // 禁止显示默认的上下文菜单
        core.Settings.AreDefaultContextMenusEnabled = false;

        // 是否渲染默认的Javascript对话框，如alert,confirm,prompt,beforeunload等对话框。
        core.Settings.AreDefaultScriptDialogsEnabled = true;

        // 禁止使用上下文菜单或键盘快捷键来打开DevTools窗口
        core.Settings.AreDevToolsEnabled = false;

        // 是否允许 web 内容访问主机对象
        core.Settings.AreHostObjectsAllowed = options.AreHostObjectsAllowed;

        // 是否禁用导航失败和渲染过程失败的内置错误页面，禁用将显示空白页。
        core.Settings.IsBuiltInErrorPageEnabled = true;

        // 是否启用一般表格信息等内容信息的保存和自动填写
        core.Settings.IsGeneralAutofillEnabled = true;

        // 禁止自动保存密码信息
        core.Settings.IsPasswordAutosaveEnabled = false;

        // 禁止支持触摸输入的设备上使用捏动动作来缩放WebView2中的网页内容
        core.Settings.IsPinchZoomEnabled = false;

        // 是否允许运行 JavaScript 脚本，不影响ExecuteScriptAsync方法执行脚本。
        core.Settings.IsScriptEnabled = true;

        // 是否显示状态栏
        core.Settings.IsStatusBarEnabled = false;

        // 是否在支持触摸输入的设备上使用刷卡手势来浏览WebView2
        core.Settings.IsSwipeNavigationEnabled = false;

        // 是否允许从主机到WebView的顶级HTML文档的通信
        core.Settings.IsWebMessageEnabled = true;

        // 是否允许使用鼠标滚轮和键盘操作，来缩放WebView控件中的内容；不影响ZoomFactor属性。
        core.Settings.IsZoomControlEnabled = true;
    }
}