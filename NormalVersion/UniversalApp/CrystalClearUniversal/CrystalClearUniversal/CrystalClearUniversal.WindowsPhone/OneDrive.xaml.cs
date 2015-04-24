using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CrystalClearUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OneDrive : Page
    {
        public OneDrive()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

          private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Uri targetUri = new Uri(@"https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1396013362&rver=6.4.6456.0&wp=MBI_SSL_SHARED&wreply=https:%2F%2Fonedrive.live.com%2F%3Fgologin%3D1%26mkt%3Den-GB&lc=2057&id=250206&cbcxt=sky&mkt=en-GB&cbcxt=sky");
            webView1.Navigate(targetUri);
        }

          private void back_Btn(object sender, RoutedEventArgs e)
          {
              Frame.Navigate(typeof(MainPage));
          }

         

    }


  
}
