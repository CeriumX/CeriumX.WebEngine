@echo off
@title 自动创建解决方案及各隶属项目

set basedir="%~dp0"
set basedir
cd /d %basedir%



@echo.
@echo.
@echo.
@echo\&echo  ---------- 解决方案 ----------

dotnet new sln -n CRS2TBBT4CeriumX.WebEngine





@echo.
@echo.
@echo.
@echo\&echo  ---------- 引导程序 & Bootstrapper 1 ----------

dotnet new console -lang C# -f net6.0 -n CeriumX.WebEngine.Bootstrapper -o samples/CeriumX.WebEngine.Bootstrapper/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s samples samples/CeriumX.WebEngine.Bootstrapper/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 示例程序 & samples 2 ----------

dotnet new wpf -lang "C#" -f net6.0 -n CeriumX.WebEngine.Appx4WPF -o samples/CeriumX.WebEngine.Appx4WPF/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s samples samples/CeriumX.WebEngine.Appx4WPF/src

dotnet new winforms -lang "C#" -f net6.0 -n CeriumX.WebEngine.Appx4WinForm -o samples/CeriumX.WebEngine.Appx4WinForm/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s samples samples/CeriumX.WebEngine.Appx4WinForm/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- 接口抽象 ﹫ Abstractions 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.Abstractions -o CeriumX.WebEngine.Abstractions/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add --in-root CeriumX.WebEngine.Abstractions/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- WEB引擎实现与扩展 & WebView2集成 ﹫ WebView2 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.WebView2 -o WebView2/CeriumX.WebEngine.WebView2/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s WebView2 WebView2/CeriumX.WebEngine.WebView2/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.WebView2.GenericHost -o WebView2/CeriumX.WebEngine.WebView2.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s WebView2 WebView2/CeriumX.WebEngine.WebView2.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.WebView2.CeriumXHost -o WebView2/CeriumX.WebEngine.WebView2.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s WebView2 WebView2/CeriumX.WebEngine.WebView2.CeriumXHost/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- WEB引擎实现与扩展 & CefSharp集成 ﹫ CefSharp 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.CefSharp -o CefSharp/CeriumX.WebEngine.CefSharp/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s CefSharp CefSharp/CeriumX.WebEngine.CefSharp/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.CefSharp.GenericHost -o CefSharp/CeriumX.WebEngine.CefSharp.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s CefSharp/ CefSharp/CeriumX.WebEngine.CefSharp.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.CefSharp.CeriumXHost -o CefSharp/CeriumX.WebEngine.CefSharp.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s CefSharp CefSharp/CeriumX.WebEngine.CefSharp.CeriumXHost/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- WEB引擎实现与扩展 & ChromiumFX集成 ﹫ ChromiumFX 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.ChromiumFX -o ChromiumFX/CeriumX.WebEngine.ChromiumFX/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s ChromiumFX ChromiumFX/CeriumX.WebEngine.ChromiumFX/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.ChromiumFX.GenericHost -o ChromiumFX/CeriumX.WebEngine.ChromiumFX.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s ChromiumFX ChromiumFX/CeriumX.WebEngine.ChromiumFX.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.ChromiumFX.CeriumXHost -o ChromiumFX/CeriumX.WebEngine.ChromiumFX.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s ChromiumFX ChromiumFX/CeriumX.WebEngine.ChromiumFX.CeriumXHost/src





::@echo\&echo 所有项目自动创建工作已结束，600 秒后将自动退出本自动创建程序。
::timeout /t 600

@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo 所有项目自动创建完毕，请按任意键退出。
pause>nul 
exit
