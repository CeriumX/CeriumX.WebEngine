//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：BrowserCommands.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-14 10:02:05
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System.Windows.Input;

namespace CeriumX.WebEngine.Appx4WPF.Commands;

/// <summary>
/// 浏览器路由命令
/// </summary>
internal static class BrowserCommands
{
    /// <summary>
    /// 后退路由命令
    /// </summary>
    public static RoutedCommand GoBackCommand { get; } = new();

    /// <summary>
    /// 前进路由命令
    /// </summary>
    public static RoutedCommand GoForwardCommand { get; } = new();
}