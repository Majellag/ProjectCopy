using CrystalClearUniversal.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

using System.Threading.Tasks;
using System.Xml.Serialization;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CrystalClearUniversal
{

    public sealed partial class MeterReading : Page
    {
        List<Reading> Readings = new List<Reading>();
        StorageFolder StorageFolder = null;
        const string filename = "sampleFile.txt";
        string currentAmt;
        DailyRead tip;
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();


        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }


        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

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
            tip = new DailyRead();
            StorageFolder = ApplicationData.Current.RoamingFolder;//will create a sampleFile.txt under the RoamingState folder

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

       
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
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
            billAmountTextBox.Text = tip.LitreAmount.ToString();
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
            
            WriteText(currentAmt);
            billAmountTextBox.Text = "";
            //for(int i = 0; i< 4;i++)
            //{
            //   Reading temp = new Reading();
            //    temp.Name = "Name";
            //    temp.Power = 12;
            //    Sample.Add(temp);
            //}
            Reading reading = new Reading();
            // find day number
            reading.Day = daynum;
            DateTime now = DateTime.Now;
            string date = now.GetDateTimeFormats('d')[0];
           //reading.Amount = billAmountTextBox.Text;
           //reading.Amount = Int32.Parse("billAmountTextBox.Text");



            Readings.Add(reading);
            Save_To_XML(Readings);

        }

        private async void Save_To_XML(List<Reading> temp)
        {

            await SaveObjectToXml(temp, "Reading.xml"); 
        }

        public static async Task<T> ReadObjectFromXmlFileAsync<T>(string filename)
        {
            // this reads XML content from a file ("filename") and returns an object  from the XML
            T objectFromXml = default(T);
            var serializer = new XmlSerializer(typeof(T));
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync(filename);
            Stream stream = await file.OpenStreamForReadAsync();
            objectFromXml = (T)serializer.Deserialize(stream);
            stream.Dispose();
            return objectFromXml;
        }

        private void View_History_Btn(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(GraphPage));
            ReadText();
        }

        async void ReadText()
        {

            StorageFile file = await StorageFolder.GetFileAsync(filename);
            TextBlock1.Text = await FileIO.ReadTextAsync(file);

        }
        async void WriteText(string s)
        {
            StorageFile file = await StorageFolder.GetFileAsync(filename);
            string temp = await FileIO.ReadTextAsync(file);
            temp = temp + "\n" + s;
            StorageFile writefile = await StorageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(writefile, temp);
           
        }


        public string daynum { get; set; }
    }
}
