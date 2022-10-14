//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：WebEngineHostedService.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-14 11:45:03
// 创建人员：宋杰军
// 电子邮件：cockroach888@outlook.com
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using CeriumX.WebEngine.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CeriumX.WebEngine.WebView2.GenericHost;

/// <summary>
/// Web引擎服务产品中间件后台托管服务
/// </summary>
internal sealed class WebEngineHostedService : IHostedService
{
    private readonly ILogger<WebEngineHostedService> _logger;
    private readonly IWebWindowFactory _factory;


    /// <summary>
    /// Web引擎服务产品中间件后台托管服务
    /// </summary>
    /// <param name="logger">日志服务</param>
    /// <param name="factory">Web引擎创建工厂服务</param>
    /// <param name="lifetime">应用程序生命周期服务</param>
    public WebEngineHostedService(ILogger<WebEngineHostedService> logger, IWebWindowFactory factory, IHostApplicationLifetime lifetime)
    {
        _logger = logger;
        _factory = factory;

        // NOTE: 此处非常有玄机！即线程问题，通常UI线程是独立的，而这里的注入就很有讲究了。
        // 对于通用主机，只要在应用程序开始后的事件中注入，使用时如出现线程问题，再议。
        lifetime.ApplicationStarted.Register(async (sender) =>
        {
            IWebWindowFactory? innerFactory = sender as IWebWindowFactory;

            if (innerFactory is not null)
            {
                _logger.LogDebug($"初始化Web引擎服务产品中间件运行环境。");

                await innerFactory.InitializeEnvironmentAsync().ConfigureAwait(false);
            }
        }, factory);

        _logger.LogDebug($"实例化Web引擎服务产品中间件后台托管服务。");
    }


    /// <summary>
    /// 启动
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(0).ConfigureAwait(false);
    }

    /// <summary>
    /// 停止
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>表示响应当前异步操作的支持对象</returns>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _factory.Dispose();
        await Task.Delay(0).ConfigureAwait(false);
    }
}