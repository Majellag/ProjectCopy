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
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CrystalClearUniversal
{
    public sealed partial class CreateAccount : Page
    {
        StorageFolder StorageFolder = null;
        const string filename = "sampleFile.txt";


        //StorageFolder = ApplicationData.Current.RoamingFolder; 

        DailyRead tip;
        TimeSpan t = new TimeSpan(0, 0, 2);
        public CreateAccount()
        {
            StorageFolder = ApplicationData.Current.RoamingFolder;//will create a sampleFile.txt under the RoamingState folder.

            tip = new DailyRead();

            this.InitializeComponent();
        }

        private void Add_Account_Btn(object sender, RoutedEventArgs e)
        {

            WriteText();
        }

        private void View_Account_Btn(object sender, RoutedEventArgs e)
        {
            ReadText();
           // await Task.Delay(10000);

        }

        async void ReadText()
        {

            StorageFile file = await StorageFolder.GetFileAsync(filename);
            TextBlock1.Text = await FileIO.ReadTextAsync(file);

        }
        async void WriteText()
        {
            StorageFile file = await StorageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, familyNmeTxtBx.Text + "\n" + numberTxtBx.Text + "\n" + emailTxtBx.Text);



        }

        private void Go_To_MeterReading_Btn(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MeterReading));
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
