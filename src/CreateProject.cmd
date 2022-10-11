@echo off
@title �Զ����������������������Ŀ

set basedir="%~dp0"
set basedir
cd /d %basedir%



@echo.
@echo.
@echo.
@echo\&echo  ---------- ������� ----------

dotnet new sln -n CRS2TBBT4CeriumX.WebEngine





@echo.
@echo.
@echo.
@echo\&echo  ---------- �������� & Bootstrapper 1 ----------

dotnet new console -lang C# -f net6.0 -n CeriumX.WebEngine.Bootstrapper -o samples/CeriumX.WebEngine.Bootstrapper/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s samples samples/CeriumX.WebEngine.Bootstrapper/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- ʾ������ & samples 2 ----------

dotnet new wpf -lang "C#" -f net6.0 -n CeriumX.WebEngine.Appx4WPF -o samples/CeriumX.WebEngine.Appx4WPF/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s samples samples/CeriumX.WebEngine.Appx4WPF/src

dotnet new winforms -lang "C#" -f net6.0 -n CeriumX.WebEngine.Appx4WinForm -o samples/CeriumX.WebEngine.Appx4WinForm/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s samples samples/CeriumX.WebEngine.Appx4WinForm/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- �ӿڳ��� �� Abstractions 1 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.Abstractions -o CeriumX.WebEngine.Abstractions/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add --in-root CeriumX.WebEngine.Abstractions/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- WEB����ʵ������չ & WebView2���� �� WebView2 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.WebView2 -o WebView2/CeriumX.WebEngine.WebView2/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s WebView2 WebView2/CeriumX.WebEngine.WebView2/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.WebView2.GenericHost -o WebView2/CeriumX.WebEngine.WebView2.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s WebView2 WebView2/CeriumX.WebEngine.WebView2.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.WebView2.CeriumXHost -o WebView2/CeriumX.WebEngine.WebView2.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s WebView2 WebView2/CeriumX.WebEngine.WebView2.CeriumXHost/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- WEB����ʵ������չ & CefSharp���� �� CefSharp 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.CefSharp -o CefSharp/CeriumX.WebEngine.CefSharp/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s CefSharp CefSharp/CeriumX.WebEngine.CefSharp/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.CefSharp.GenericHost -o CefSharp/CeriumX.WebEngine.CefSharp.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s CefSharp/ CefSharp/CeriumX.WebEngine.CefSharp.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.CefSharp.CeriumXHost -o CefSharp/CeriumX.WebEngine.CefSharp.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s CefSharp CefSharp/CeriumX.WebEngine.CefSharp.CeriumXHost/src





@echo.
@echo.
@echo.
@echo\&echo  ---------- WEB����ʵ������չ & ChromiumFX���� �� ChromiumFX 3 ----------

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.ChromiumFX -o ChromiumFX/CeriumX.WebEngine.ChromiumFX/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s ChromiumFX ChromiumFX/CeriumX.WebEngine.ChromiumFX/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.ChromiumFX.GenericHost -o ChromiumFX/CeriumX.WebEngine.ChromiumFX.GenericHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s ChromiumFX ChromiumFX/CeriumX.WebEngine.ChromiumFX.GenericHost/src

dotnet new classlib -lang "C#" -f net6.0 -n CeriumX.WebEngine.ChromiumFX.CeriumXHost -o ChromiumFX/CeriumX.WebEngine.ChromiumFX.CeriumXHost/src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add -s ChromiumFX ChromiumFX/CeriumX.WebEngine.ChromiumFX.CeriumXHost/src





::@echo\&echo ������Ŀ�Զ����������ѽ�����600 ����Զ��˳����Զ���������
::timeout /t 600

@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo ������Ŀ�Զ�������ϣ��밴������˳���
pause>nul 
exit
