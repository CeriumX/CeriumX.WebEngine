//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IWebWindow.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 14:51:33
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Drawing;

namespace CeriumX.WebEngine.Abstractions;

/// <summary>
/// 浏览器窗口接口
/// </summary>
/// <remarks>控件类型必须为 System.Windows.Forms.Control 或者 System.Windows.UIElement 两者之一</remarks>
/// <typeparam name="TControlType">用于作为浏览器控件的承载控件类型</typeparam>
public interface IWebWindow<TControlType> : IDisposable
        where TControlType : class
{
    /// <summary>
    /// 用于承载浏览器窗口的控件
    /// </summary>
    TControlType? BrowserControl { get; }

    /// <summary>
    /// 浏览器
    /// </summary>
    IWebBrowser? Browser { get; }

    /// <summary>
    /// 默认的背景色
    /// </summary>
    Color DefaultBackgroundColor { get; set; }

    /// <summary>
    /// 缩放系数（默认1.0）
    /// </summary>
    /// <remarks>用于设置页面的缩放系数，数值区间为0-1之间。</remarks>
    double ZoomFactor { get; set; }


    /// <summary>
    /// WebBrowser初始化完成时事件
    /// </summary>
    event EventHandler<WebBrowserInitializationCompletedWebArgs> OnWebBrowserInitializationCompleted;

    /// <summary>
    /// 导航操作完成时事件
    /// </summary>
    event EventHandler<NavigationCompletedWebArgs> OnNavigationCompleted;

    /// <summary>
    /// 缩放系数属性改变事件
    /// </summary>
    event EventHandler<EventArgs> ZoomFactorChanged;
}