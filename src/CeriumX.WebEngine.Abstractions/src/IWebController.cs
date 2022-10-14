//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：IWebController.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 14:54:19
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

namespace CeriumX.WebEngine.Abstractions;

/// <summary>
/// CSharp对象注册控制器接口
/// </summary>
#pragma warning disable CS0618 // 类型或成员已过时
[InterfaceType(ComInterfaceType.InterfaceIsDual)]
#pragma warning restore CS0618 // 类型或成员已过时
[ComVisible(true)]
public interface IWebController : IDisposable
{
    /// <summary>
    /// 将CSharp对象注册为JS对象的控制器名称
    /// </summary>
    string ControllerName { get; }
}