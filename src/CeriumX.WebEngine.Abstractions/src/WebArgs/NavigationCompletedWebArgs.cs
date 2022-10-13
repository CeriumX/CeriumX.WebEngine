//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：NavigationCompletedWebArgs.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-13 14:55:34
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
/// 导航操作完成时事件参数类
/// </summary>
public sealed class NavigationCompletedWebArgs : EventArgs
{
    /// <summary>
    /// 导航操作完成时事件参数
    /// </summary>
    /// <param name="isSuccess">导航操作是否成功</param>
    /// <param name="navigationId">当前导航事件的编号</param>
    /// <param name="webErrorStatus">导航失败的错误代码</param>
    public NavigationCompletedWebArgs(bool isSuccess, ulong navigationId, uint webErrorStatus)
    {
        IsSuccess = isSuccess;
        NavigationId = navigationId;
        WebErrorStatus = webErrorStatus;
    }


    /// <summary>
    /// 导航操作是否成功
    /// </summary>
    /// <remarks>
    /// <para>当导航成功时为true。</para>
    /// <para>当导航结束于错误页面时为false（由于没有网络、DNS查询失败、HTTP服务器响应4xx而导致的失败）。</para>
    /// </remarks>
    public bool IsSuccess { get; }

    /// <summary>
    /// 当前导航事件的编号
    /// </summary>
    public ulong NavigationId { get; }

    /// <summary>
    /// 导航失败的错误代码
    /// </summary>
    public uint WebErrorStatus { get; }
}