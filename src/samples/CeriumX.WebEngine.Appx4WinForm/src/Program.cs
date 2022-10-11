using System;

namespace CeriumX.WebEngine.Appx4WinForm;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.

#if NET6_0_OR_GREATER
        ApplicationConfiguration.Initialize();
#else
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#endif

        Application.Run(new MainForm());
    }    
}