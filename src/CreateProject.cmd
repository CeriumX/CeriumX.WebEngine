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
@echo\&echo  ---------- �������� & Bootloader 1 ----------

dotnet new classlib -lang "C#" -f net5.0 -n CeriumX.WebEngine.Bootloader -o CeriumX.WebEngine.Bootloader\src
dotnet sln CRS2TBBT4CeriumX.WebEngine.sln add --in-root CeriumX.WebEngine.Bootloader\src





@echo.
@echo.
@echo.
@echo\&echo  ---------- ��Ŀ��� �� ProjectCategory 10 ----------

dotnet new web -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new blazorserver -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new blazorwasm -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new mvc -lang C# -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new webapi -lang "C#" -f net6.0 --exclude-launch-settings --no-https -n LibrayName -o LibrayName/src
dotnet sln SolutionName.sln add --in-root LibrayName/src

dotnet new winforms -lang "C#" -f net6.0 -n LibrayName -o samples/LibrayName/src
dotnet sln SolutionName.sln add -s samples samples/LibrayName/src

dotnet new wpf -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src

dotnet new console -lang C# -f net6.0 -n LibrayName -o samples/LibrayName/src
dotnet sln SolutionName.sln add -s samples samples/LibrayName/src

dotnet new classlib -lang "C#" -f net6.0 -n LibrayName -o LibrayName/src
dotnet sln SolutionName.sln add --in-root LibrayName/src

dotnet new classlib -lang "C#" -f net6.0 -n LibrayName -o ProjectCategory/LibrayName/src
dotnet sln SolutionName.sln add -s ProjectCategory ProjectCategory/LibrayName/src





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
