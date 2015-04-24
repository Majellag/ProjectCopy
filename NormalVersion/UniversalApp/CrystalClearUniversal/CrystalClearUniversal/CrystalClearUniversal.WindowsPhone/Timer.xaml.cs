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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CrystalClearUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Timer : Page
    {
        private DispatcherTimer timer;
        private TimeSpan timeSpan;
        public Timer()
        {
            this.InitializeComponent();
            this.timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            this.timer.Tick += TimerOnTick;

            this.timeSpan = new TimeSpan();

            this.txtHour.Text = DateTime.Now.ToString("HH:MM:ss");
            var t = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            t.Tick += (s, e) => this.txtHour.Text = DateTime.Now.ToString("HH:MM:ss");
            t.Start();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void TimerOnTick(object sender, object o)
        {
            this.timeSpan = this.timeSpan.Add(TimeSpan.FromSeconds(1));
            this.txtDuration.Text = this.timeSpan.ToString("c");
        }

        private void OnButtonStartClick(object sender, RoutedEventArgs e)
        {
            this.timer.Start();
        }

        private void OnButtonPauseClick(object sender, RoutedEventArgs e)
        {
            this.timer.Stop();
        }

        private void OnButtonStopClick(object sender, RoutedEventArgs e)
        {
            this.timeSpan = new TimeSpan();
            this.timer.Stop();

            this.txtDuration.Text = this.timeSpan.ToString("c");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void back_Btn(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


    }
}
