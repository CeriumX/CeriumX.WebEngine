//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：MessageController.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-14 10:09:08
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Runtime.InteropServices;
using System.Windows;

namespace CeriumX.WebEngine.Appx4WPF.Controllers;

/// <summary>
/// 消息控制器
/// </summary>
/// <remarks>
/// <para>await chrome.webview.hostObjects.message.ShowMsg('This is haha.')</para>
/// <para>await chrome.webview.hostObjects.message.Prop</para>
/// </remarks>
#pragma warning disable CS0618 // 类型或成员已过时
[ClassInterface(ClassInterfaceType.AutoDual)]
#pragma warning restore CS0618 // 类型或成员已过时
[ComVisible(true)]
public sealed class MessageController : IWebController
{
    /// <summary>
    /// 
    /// </summary>
    public string Prop { get; set; } = "Example";


    /// <summary>
    /// 显示信息
    /// </summary>
    /// <param name="msg">需要显示的信息</param>
    public void ShowMsg(string msg)
    {
        MessageBox.Show(msg);
    }


    #region 接口实现[IWebController]

    /// <summary>
    /// 将CSharp对象注册为JS对象的控制器名称
    /// </summary>
    public string ControllerName { get; } = "message";

    /// <summary>
    /// 资源释放
    /// </summary>
    public void Dispose()
    {
        // do something.
    }

    #endregion

}