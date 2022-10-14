using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CeriumX.WebEngine.Appx4WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IWebWindowFactory? _webFactory;
    private IWebWindow<UIElement>? _webWindow;


    /// <summary>
    /// 
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // do something.
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected override async void OnInitialized(EventArgs e)
    {
        base.OnInitialized(e);

        try
        {
            string webViewFolder = System.IO.Path.GetFullPath("d:/data/WebView2Fixed");
            string userDataFolder = System.IO.Path.GetFullPath("d:/data/WebView2Fixed/UserData");

            _webFactory = WebWindowFactoryProvider.CreateWebWindowFactory(
                browserExecutableFolder: webViewFolder,
                userDataFolder: userDataFolder,
                nlogRulePrefixName: "Monica");
            await _webFactory.InitializeEnvironmentAsync().ConfigureAwait(false);

            WebOptions options = WebOptions.Create(@"http://localhost");
            _webWindow = await _webFactory.CreateAsync<UIElement>(options).ConfigureAwait(false);
            mainContent.Child = _webWindow.BrowserControl;

            _webWindow.OnWebBrowserInitializationCompleted += (sender, e) =>
            {
                if (e.IsSuccess)
                {
                    _webWindow?.Browser?.AddControllerToScript(new MessageController());
                }
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "系统提示", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnTest_Click(object sender, RoutedEventArgs e)
    {
        if (_webWindow != null && _webWindow.Browser != null)
        {
            _webWindow?.Browser?.Navigate(txtAddress.Text.Trim());
        }
    }

    private void GoBack_Click(object target, ExecutedRoutedEventArgs e)
    {
        _webWindow?.Browser?.GoBack();
    }

    private void GoForward_Click(object target, ExecutedRoutedEventArgs e)
    {
        _webWindow?.Browser?.GoForward();
    }

    private void BtnTaskMgr_Click(object sender, RoutedEventArgs e)
    {
        _webWindow?.Browser?.OpenTaskManagerWindow();
    }

    private void BtnDevTool_Click(object sender, RoutedEventArgs e)
    {
        _webWindow?.Browser?.OpenDevToolsWindow();
    }

    private void BtnConsoleLog_Click(object sender, RoutedEventArgs e)
    {
        if (_webWindow != null && _webWindow.Browser != null)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    string result = await _webWindow.Browser.ExecuteScriptAsync($"console.log({i})");
            //    Console.WriteLine(result);
            //}

            Parallel.For(0, 10, (i) =>
            {
                Dispatcher.BeginInvoke(async () =>
                {
                    string result = await _webWindow.Browser.ExecuteScriptAsync($"console.log({i})").ConfigureAwait(false);
                    Console.WriteLine(result);
                });
            });
        }
    }
}
