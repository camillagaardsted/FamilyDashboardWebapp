using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FamilyDashboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();
            LocalAppSettings.SetSettings();
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            txtBlockNameChild1.Text = (string)localSettings.Values["childname1"];
            txtBlockNameChild2.Text = (string)localSettings.Values["childname2"];
            txtBlockNameChild3.Text = (string)localSettings.Values["childname3"];

        }

        private async void webviewWeather_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            string ScrollToTopString = @"window.scrollTo(110,250);";
            await webviewWeather.InvokeScriptAsync("eval", new string[] { ScrollToTopString });


        }

        private async void webviewChild1_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            string url = webviewChild1.Source.AbsoluteUri;
            string skoleurl = (string)localSettings.Values["skoleurl"];
            string emuurl = (string)localSettings.Values["emuloginurl"];
            if (url.Contains(skoleurl) && !url.Contains("parent") && !url.Contains("sso"))
            {
                string clickUnilogin = @"document.getElementsByTagName('a')[4].click();";
                await webviewChild1.InvokeScriptAsync("eval", new string[] { clickUnilogin });
            }
            else if (url.Contains(emuurl))
            {
                string commandscript = String.Format("if (document.getElementById('user') != null) document.getElementById('user').value = '{0}'; if (document.getElementById('pass') != null) document.getElementById('pass').value='{1}'; if (document.getElementsByTagName('form') != null) document.getElementsByTagName('form')[0].submit(); ", localSettings.Values["FIUsername"], localSettings.Values["FIPassword"]);
                await webviewChild1.InvokeScriptAsync("eval", new string[] { commandscript });
            }
            else if (url.Contains("Caroline"))
            {
                string urlChild2 = webviewChild2.Source.AbsoluteUri;
               if (urlChild2.Contains(skoleurl) && !urlChild2.Contains("parent") && !urlChild2.Contains("sso"))
                {
                    string clickUnilogin = @"document.getElementsByTagName('a')[4].click();";
                    await webviewChild2.InvokeScriptAsync("eval", new string[] { clickUnilogin });
                }
                string urlChild3 = webviewChild3.Source.AbsoluteUri;

                if (urlChild3.Contains(skoleurl) && !urlChild3.Contains("parent") && !urlChild3.Contains("sso"))
                {                    string clickUnilogin = @"document.getElementsByTagName('a')[4].click();";
                    await webviewChild3.InvokeScriptAsync("eval", new string[] { clickUnilogin });
                }



            }
        }

        private void webviewChild2_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            if (webviewChild2.Source.AbsoluteUri.Contains("parent") && !webviewChild2.Source.AbsoluteUri.Contains("weekly"))
            {
                DateTime dt = DateTime.Now.AddDays(7);
                string homeworkurl = (string)localSettings.Values["child2homeworkurl"];
                Uri uri = new Uri(string.Format(homeworkurl, dt.Ticks));
                webviewChild2.Navigate(uri);
            }
        }

        private void webviewChild3_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            if (webviewChild3.Source.AbsoluteUri.Contains("parent") && !webviewChild3.Source.AbsoluteUri.Contains("weekly"))
            {

                DateTime dt = DateTime.Now.AddDays(7);

                string homeworkurl = (string)localSettings.Values["child3homeworkurl"];
                Uri uri = new Uri(string.Format(homeworkurl, dt.Ticks));
                webviewChild3.Navigate(uri);
            }
        }
    }
}
