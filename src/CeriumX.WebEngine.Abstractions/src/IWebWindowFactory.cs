//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IWebWindowFactory.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 14:00:11
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
/// 浏览器窗口创建工厂接口
/// </summary>
public interface IWebWindowFactory : IAsyncDisposable
{
    /// <summary>
    /// 初始化运行环境
    /// </summary>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    Task InitializeEnvironmentAsync();

    /// <summary>
    /// 创建一个浏览器窗口
    /// </summary>
    /// <remarks>控件类型必须为 System.Windows.Forms.Control 或者 System.Windows.UIElement 两者之一</remarks>
    /// <typeparam name="TControlType">用于作为浏览器控件的承载控件类型</typeparam>
    /// <param name="option">WebEngine创建选项(参数)</param>
    /// <returns>浏览器窗口</returns>
    Task<IWebWindow<TControlType>> CreateAsync<TControlType>(WebOptions option)
        where TControlType : class;
}