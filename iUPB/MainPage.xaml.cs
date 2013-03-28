using iUPB.Common;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace iUPB
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Uri _iupbUrl = new Uri(ConfigProvider.Instance.Get("root_url", "http://www.i-upb.de"));

        public MainPage()
        {
            this.InitializeComponent();
            this.MainWebView.Navigate(_iupbUrl);
            MainWebView.NavigationFailed += OnNavigationError;
        }

        private async void OnNavigationError(object sender, WebViewNavigationFailedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Sorry, aber du brauchst leider Internet", "Kein Internet");
            bool? result = null;
            md.Commands.Add(
               new UICommand("Neu laden", new UICommandInvokedHandler((cmd) => result = true)));
            md.Commands.Add(
               new UICommand("App beenden", new UICommandInvokedHandler((cmd) => result = false)));

            await md.ShowAsync();
            if (result == true)
                MainWebView.Navigate(_iupbUrl);
            else
                Application.Current.Exit();
        }

        /// <summary>
        /// Wird aufgerufen, wenn diese Seite in einem Rahmen angezeigt werden soll.
        /// </summary>
        /// <param name="e">Ereignisdaten, die beschreiben, wie diese Seite erreicht wurde. Die
        /// Parametereigenschaft wird normalerweise zum Konfigurieren der Seite verwendet.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}