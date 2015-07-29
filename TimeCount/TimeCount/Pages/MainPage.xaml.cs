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

//registry namespace
using Microsoft.Win32;

//Pie 
using TimeCount.PieControl;
using TimeCount.Pie;
using TimeCount.Methods;
using TimeCount.ViewModels;
namespace TimeCount.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        #region"Colors"
        // colors for the chart
        private Color[] _Colors = new Color[]{
             Color.FromRgb(0x33, 0x99, 0xff),   // blue
            //Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x33, 0x99, 0x33),   // green
            Color.FromRgb(0x8c, 0xbf, 0x26),   // lime
            //Color.FromRgb(0xf0, 0x96, 0x09),   // orange
            Color.FromRgb(0xff, 0x45, 0x00),   // orange red
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xff, 0x00, 0x97),   // magenta
            Color.FromRgb(0xa2, 0x00, 0xff),   // purple     
            Color.FromRgb(0xa4, 0xc4, 0x00),   // lime
            Color.FromRgb(0x60, 0xa9, 0x17),   // green
            Color.FromRgb(0x00, 0x8a, 0x00),   // emerald
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            //Color.FromRgb(0x1b, 0xa1, 0xe2),   // cyan
            //Color.FromRgb(0x00, 0x50, 0xef),   // cobalt
            // Color.FromRgb(0x6a, 0x00, 0xff),   // indigo
            Color.FromRgb(0xaa, 0x00, 0xff),   // violet
            Color.FromRgb(0xf4, 0x72, 0xd0),   // pink
            Color.FromRgb(0xd8, 0x00, 0x73),   // magenta
            Color.FromRgb(0xa2, 0x00, 0x25),   // crimson
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xfa, 0x68, 0x00),   // orange
            Color.FromRgb(0xf0, 0xa3, 0x0a),   // amber
            Color.FromRgb(0xe3, 0xc8, 0x00),   // yellow
            Color.FromRgb(0x82, 0x5a, 0x2c),   // brown
            Color.FromRgb(0x6d, 0x87, 0x64),   // olive
            Color.FromRgb(0x64, 0x76, 0x87),   // steel
            Color.FromRgb(0x76, 0x60, 0x8a),   // mauve
        };
        #endregion 

        string Date;
        int TotalSec;
        int ColorCount;
        int ReturnedSeconds;
        internal static MainPage main1;
        PieDataCollection<PieSegment> collection;
        MySqlDataBase _MySqlDataBase = new MySqlDataBase();
        AccountViewModel _AccountViewModel = new AccountViewModel();
        public MainPage()
        {
            InitializeComponent();
            main1 = this;
            IsMySqlSource = false;
            chart1.PopupBrush = Brushes.LightBlue;
            //initialize the chart with the current data
            InitializeChart("SOFTWARE\\TimeCount\\" + DateTime.Now.Month + "\\" + DateTime.Now.ToString("d"));
            CurrentDateLbl.Content = "Source date: " + DateTime.Now.ToString("d") + " (from pc)";
            //if user loged in, we load data directly from the db
            if (Properties.Settings.Default.SignedIn) IsMySqlSource = true;   
        }

        private bool IsMySqlSource { get; set; }
  
        private void Calender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //check if we connected to the database to load data from there   
            int SpaceIndex = Calender.SelectedDate.ToString().LastIndexOf(" ");
            Date = Calender.SelectedDate.ToString().Remove(SpaceIndex, Calender.SelectedDate.ToString().Length - SpaceIndex);
           // MessageBox.Show(Date);
            if (IsMySqlSource)
            {
                _AccountViewModel.Date = Date;
                //MessageBox.Show(Date);
                _MySqlDataBase.GetMySqlData();
            }
            else
            {
                InitializeChart("SOFTWARE\\TimeCount\\" + Calender.SelectedDate.Value.Month.ToString() + "\\" + Date);
                CurrentDateLbl.Content = "Source date: " + Date + " (from pc)";
            }
        }

        internal string ReturnedMySqlData
        {
            //returned data from database
            set { Dispatcher.Invoke(new Action(() => {
                ColorCount = ReturnedSeconds = TotalSec = 0;  
               // MessageBox.Show(value);
                collection = new PieDataCollection<PieSegment>();
                if (value != "no data found")
                {
                    //split the mysql string to get the progress
                    foreach (string Item in value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        //split the string value at "|"
                        var parts = Item.Split(new char[] { '|' });
                        //MessageBox.Show("app: " + parts[0] + " value: " + parts[1]);
                        //parts[0] - represend the app name
                        //parts[1] - represent the total spenden time in string, but we convert it in to int32
                        ReturnedSeconds = Convert.ToInt32(parts[1]);
                        collection.Add(new PieSegment { Color = _Colors[ColorCount], Value = ReturnedSeconds, Name = parts[0].ToString() });
                        TotalSec += ReturnedSeconds;
                        ColorCount++;
                    }
                }
                ToatalSpendTimeLbl.Content = "Total spended time in this day: " + TimeSpan.FromSeconds(TotalSec).ToString();
                //MessageBox.Show(value);
                if (ColorCount == 0)
                {
                    StatusLbl.Visibility = System.Windows.Visibility.Visible;
                    CurrentDateLbl.Content = "No save data for " + Date;
                }
                else
                {
                    CurrentDateLbl.Content = "Source date: " + Date + " (from database)";
                    StatusLbl.Visibility = System.Windows.Visibility.Hidden;
                }
                //insert data to the pie chart
                chart1.Data = collection;
            })); }
        }
      
        void InitializeChart(string RegLocation)
        {
            collection = new PieDataCollection<PieSegment>();
            //clear values
            ColorCount = ReturnedSeconds = TotalSec = 0;
            try
            {
                //get all value in a key(from reg.)
                foreach (string aplicatie in Registry.CurrentUser.OpenSubKey(RegLocation, true).GetValueNames())
                {
                    //get the stored seconds for the source app name
                    ReturnedSeconds = Convert.ToInt32(Registry.CurrentUser.OpenSubKey(RegLocation, true).GetValue(aplicatie));
                    //add the item to the pie collection
                    //set the next found color in the array to the pie chart
                    //set the name of the application and the value by seconds
                    collection.Add(new PieSegment { Color = _Colors[ColorCount], Value = ReturnedSeconds, Name = aplicatie.ToString() });
                    //store all seconds in a int var to calculate the total spended time
                    TotalSec += ReturnedSeconds;
                    //represent the next color in the array
                    ColorCount++;
                }
                //update the UI with the total spended time
                ToatalSpendTimeLbl.Content = "Total spended time in this day: " + TimeSpan.FromSeconds(TotalSec).ToString();
                if (TotalSec == 0) { 
                    StatusLbl.Visibility = System.Windows.Visibility.Visible;
                    collection.Clear();
                }
                else
                {
                    StatusLbl.Visibility = System.Windows.Visibility.Hidden;
                }
            }
            catch (NullReferenceException)
            {//this error appers when no data found in the specified key of the reg. directory
                //Try to create the application registry key
                Registry.CurrentUser.CreateSubKey(RegLocation);
            }
            chart1.Data = collection;
        }

        private void MyPcSourceBtn_Click(object sender, RoutedEventArgs e)
        {
            IsMySqlSource = false;
            //InitializeChart("SOFTWARE\\TimeCount\\" + Calender.SelectedDate.Value.Month.ToString() + "\\" + Date);
            //CurrentDateLbl.Content = "Source date: " + Date + " (from pc)";
        }

        private void DbSourceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SignedIn && System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
              IsMySqlSource = true;
              //_MySqlDataBase.GetMySqlData(Date);
              //CurrentDateLbl.Content = "Source date: " + Date + " (from database)";
            }
            else if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable()) MessageBox.Show("Please sign in!");
            else MessageBox.Show("Please connect the internet!");
        }
    }
}
//public bool IsConnected;
//internal bool ReturnedMySqlConnectionState
//{
//    set { Dispatcher.Invoke(new Action(() => { MessageBox.Show(value.ToString()); this.IsConnected = value; })); }
//}
