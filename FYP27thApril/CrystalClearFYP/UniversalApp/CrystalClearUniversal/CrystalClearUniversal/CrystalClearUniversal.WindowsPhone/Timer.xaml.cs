using CrystalClearUniversal.Common;
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
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
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
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }
        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
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


    }
}
