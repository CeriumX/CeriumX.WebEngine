@echo off
@title GIT �Զ����͵�Զ�ֿ̲�

set basedir="%~dp0"
set basedir


@echo\&echo ���͵� Gitee Զ�ֿ̲�
git push gitee

@echo\&echo ���͵� GitHub Զ�ֿ̲�
git push github

@echo\&echo ���͵� Bitbucket Զ�ֿ̲�
git push bitbucket

@echo\&echo ���͵� Azure Զ�ֿ̲�
git push azure

::@echo\&echo ���͵� Origin Զ�ֿ̲�
::git push origin

@echo\&echo �鿴���زֿ�״̬
git status


@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo �������Զ�ֿ̲����ͣ��밴������˳���
pause>nul 
exit