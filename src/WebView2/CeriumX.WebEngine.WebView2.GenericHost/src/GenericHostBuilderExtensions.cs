//=========================================================================
//**   Web引擎服务产品中间件（CeriumX.WebEngine）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2022 -- Support 华夏银河空间联盟
//=========================================================================
// 文件名称：GenericHostBuilderExtensions.cs
// 项目名称：Web引擎服务产品中间件
// 创建时间：2022-10-14 11:44:00
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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace CeriumX.WebEngine.WebView2.GenericHost;

/// <summary>
/// Web引擎服务产品中间件GenericHost扩展服务
/// </summary>
public static class GenericHostBuilderExtensions
{
    /// <summary>
    /// 集成Web引擎服务产品中间件
    /// </summary>
    /// <remarks>
    /// 环境目录和用户数据目录，建议使用绝对路径，如果为相对路径，将以当前程序目录作为父目录，并进行组合。
    /// <list type="bullet">
    ///     <item>通过ServiceProvider获得IWebWindowFactory服务，然后调用CreateAsync创建浏览器窗体。</item>
    /// </list>
    /// </remarks>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to configure.</param>
    /// <param name="browserExecutableFolder">运行时环境所在目录</param>
    /// <param name="userDataFolder">用户数据目录，如果为空则默认存储在运行时的UserData目录下。</param>
    /// <returns>The same instance of the <see cref="IHostBuilder"/> for chaining.</returns>
    public static IHostBuilder UseWebEngine(this IHostBuilder hostBuilder, string browserExecutableFolder, string? userDataFolder = null)
    {
        return hostBuilder.ConfigureServices((context, services) =>
        {
            services.AddHostedService<WebEngineHostedService>();

            IWebWindowFactory factory = WebWindowFactoryProvider.CreateWebWindowFactory(browserExecutableFolder, userDataFolder);
            services.TryAddSingleton(sp => factory);
        });
    }
}