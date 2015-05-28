using CrystalClearUniversal.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using System.Xml.Serialization;
using System.Threading.Tasks;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CrystalClearUniversal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MeterReading : Page
    {
        //List<Reading> Readings = new List<Reading>();
        StorageFolder StorageFolder = null;
        const string filename = "sampleFile.txt";
        string currentAmt;
        DailyRead tip;

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();


        public static async Task SaveObjectToXml<T>(T objectToSave, string filename)
        {
            // stores an object in XML format in file called 'filename'
            var serializer = new XmlSerializer(typeof(T));
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            Stream stream = await file.OpenStreamForWriteAsync();

            using (stream)
            {
                serializer.Serialize(stream, objectToSave);
            }


        }

        public MeterReading()
        {
            this.InitializeComponent();
            StorageFolder = ApplicationData.Current.RoamingFolder;//will create a sampleFile.txt under the RoamingState folder
            tip = new DailyRead();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }



        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void amountTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = "";
        }

        private void billAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            performCalculation();
        }

        private void amountTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            billAmountTextBox.Text = tip.BillAmount.ToString();
        }
        private void performCalculation()
        {

            var selectedRadio = myStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked == true);
            //line below is throwing an exception

            tip.CalculateTip(billAmountTextBox.Text, double.Parse(selectedRadio.Tag.ToString()));

            totalTextBlock.Text = tip.TipAmount;
            totalTextBlock.Text = tip.TotalAmount;
            currentAmt = tip.TotalAmount;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            performCalculation();
        }

        private void Save_Btn(object sender, RoutedEventArgs e)
        {
            WriteText();
        }

        private void View_Bill_Btn(object sender, RoutedEventArgs e)
        {
            ReadText();
        }

        async void ReadText()
        {

            StorageFile file = await StorageFolder.GetFileAsync(filename);
            totalTextBlock.Text = await FileIO.ReadTextAsync(file);

        }
        async void WriteText()
        {
            StorageFile file = await StorageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, billAmountTextBox.Text + "\n" + totalTextBlock.Text);

        }

    }
}
