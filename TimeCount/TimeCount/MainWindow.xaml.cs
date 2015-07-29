#region Libraryes
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


//using System.Security.Cryptography;
//mysql
//using MySql.Data.MySqlClient;
//thread library
using System.Threading;
//reg key namespace
using Microsoft.Win32;
using System.Diagnostics;
//Namespace for the dll importing
using System.Runtime.InteropServices;
//Storyboard
//storyboard
using System.Windows.Media.Animation;

//timecount namespaces
using TimeCount.Controls;
using TimeCount.Presentation;
using TimeCount.Pages;
using TimeCount.Methods;
using TimeCount.ViewModels;
using TimeCount.Enums;

#endregion
namespace TimeCount
{
    public partial class MainWindow : Window
    {
        #region Global var
        long StartTick;
        long TotalTicks;
        RegistryKey RegKey;
        Process foregroundProcess;
        bool signinatstart;
        internal static MainWindow main;
        //MySqlConnection Connection = null;
        public MySqlDataBase _MySqlDataBase = new MySqlDataBase();
        AccountViewModel _AccountViewModel = new AccountViewModel();
        string RegLocation = "SOFTWARE\\TimeCount\\" + DateTime.Now.Month + "\\" + DateTime.Now.ToString("d");
        #endregion

        #region Win32Api
        public class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern int GetWindowThreadProcessId(IntPtr windowHandle, out int processId);
        }
        #endregion

        #region Initializing
        public MainWindow()
        {
            InitializeComponent();
            //open the MainPage
            MainPage _MPage = new MainPage();
            PageTransitionControl.ShowPage(_MPage);
            //Button events
            this.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));
            //Apply the theme from the resources
            //Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Themes/" + Properties.Settings.Default.LastSavedTheme + ".xaml", UriKind.Relative) });
            //open new thread pool
            ThreadPool.QueueUserWorkItem(new WaitCallback(GetProcess), 1);

            BackBtn.Click += (sender, e) =>
            {
                MainPage _MainPage = new MainPage();
                PageTransitionControl.ShowPage(_MainPage);
                //x
                signup.Visibility = System.Windows.Visibility.Hidden;
            };
            AccountBtn.Click += (sender, e) =>
            {
                //NavigationBar.Visibility = System.Windows.Visibility.Hidden;
                if (Properties.Settings.Default.SignedIn && System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    //if there are loged in, then get all the wanted data

                    UserPage _UserPage = new UserPage();
                    PageTransitionControl.ShowPage(_UserPage);
                }
                else
                {
                    SignIn _SignIn = new SignIn();
                    PageTransitionControl.ShowPage(_SignIn);
                    //x
                    signup.Visibility = System.Windows.Visibility.Visible;

                    //AddNavigationBarItems(new string[] { "Sign up"}, new string[] { "Create an new user account"});
                }
            };
            main = this;
            //sign up button event
            signup.Click += (Sender, e) => PageTransitionControl.ShowPage(new CreateNewUser());
            SettingsBtn.Click += (Sender, e) =>
            {
                //usercontrool declaration for the settings
                SettingsUC newPage = new SettingsUC();
                // set the items to the combobox from the enum(PageTransitionType)
                newPage.AnimationsCb.ItemsSource = Enum.GetNames(typeof(PageTransitionType));
                //show the page
                PageTransitionControl.ShowPage(newPage);
                //x
                signup.Visibility = System.Windows.Visibility.Hidden;

                //AddNavigationBarItems(new string[] { "General", "Appearance" }, new string[] { "Your general TimeCounter setting", "Here you can change the appearance" });
            };

            //initialize the current user status to the designer
            //My.Computer.Network.IsAvailable = True
            //sign in at start
            if (Properties.Settings.Default.SignedIn && System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                AccountBtn.Content = "Sign in, please wait...";
                _AccountViewModel.UserName = Properties.Settings.Default.UserName;
                _AccountViewModel.Password = Properties.Settings.Default.UserPassword;
                signinatstart = true;
                //open the mysql class on an another thread to make the UI faster
                Thread _Thread = new Thread(delegate()
                {
                    _MySqlDataBase.SignIn();
                });
                _Thread.Start();

                //MessageBox.Show(Properties.Settings.Default.LastWrittedDate);
                //run an new thread to save the yesterday saved data in to the mysql
                Thread _ThreadTwo = new Thread(delegate()
                {
                    Properties.Settings.Default.SignedIn = true;
                    //get the yesterday date
                    DateTime Yesterday = Convert.ToDateTime(GetYesterday().ToString("d"));
                    //string YesterdayRegValues = "SOFTWARE\\TimeCount\\" + Yesterday.Month.ToString() + "\\" + Yesterday.ToString("d");
                    string YesterdayRegValues = "SOFTWARE\\TimeCount\\7\\" + "23.07.2015";
                    //check if yesterday data found and if the date was or not writted
                    if ((Registry.CurrentUser.OpenSubKey(YesterdayRegValues, false) != null) && Properties.Settings.Default.LastWrittedDate != YesterdayRegValues)
                    {
                        //put thread in sleep for 8 secounds to wait to connect to the mysql
                        if (Properties.Settings.Default.SignedIn) Thread.Sleep(8000);
                        if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                        {
                            //if no iternet connection found at this moment, we save the source date to the application settings to save it an another time
                            Properties.Settings.Default.InBearbeitung.Add(YesterdayRegValues);
                            Properties.Settings.Default.Save();
                            return;
                        }
                        //Properties.Settings.Default.LastWrittedDate = YesterdayRegValues;
                        //Properties.Settings.Default.Save();
                        //writte it in to the mysql
                        _MySqlDataBase.WritteData(YesterdayRegValues, Yesterday.ToString("d"));
                    }
                });
                //run thread
                _ThreadTwo.Start();
                //if item cont > 0 then we need to save it to the mysql
               
                if (Properties.Settings.Default.InBearbeitung != null)
                {
                    Thread _ThreadThree = new Thread(delegate()
                        {
                            foreach (string sourceDate in Properties.Settings.Default.InBearbeitung)
                            {
                                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                                {
                                    //writte it in to the mysql
                                    //get the date from the 
                                    _MySqlDataBase.WritteData(sourceDate, GetDateFromRegKey(sourceDate));
                                    //remove the source date
                                    Properties.Settings.Default.InBearbeitung.Remove(sourceDate);
                                    Properties.Settings.Default.Save();
                                }
                                else return;
                            }
                        });
                    _ThreadThree.Start();
                }
                //_MySqlDataBase.UserName = (Properties.Settings.Default.UserName == string.Empty) ? string.Empty : Properties.Settings.Default.UserName;
                //_MySqlDataBase.Password = Properties.Settings.Default.UserPassword;
            }
            else AccountBtn.Content = "Sign in";
        }
        #endregion
 
        #region Instance Tools
        private void GetProcess(object stateinformation)
        {
            int processId, LastWindowId = 0;
            do
            {
                //get the process id, ex 4353463
                var ActiveWindowId = NativeMethods.GetForegroundWindow();
                //this line check if an new application ar opened
                if (LastWindowId != (int)ActiveWindowId)
                {
                    //Save the progress for the old opened window 
                    //calculate the elepsed time
                    TotalTicks = (DateTime.Now.Ticks - StartTick) / TimeSpan.TicksPerSecond;
                    try
                    {
                        //Update the GUI //execute this block only if the GUI opened
                        //CurrentProcessName.Dispatcher.Invoke(new UpdateGUIOutsideFeedbackMessage(this.UpdateText), new object[] { foregroundProcess.ProcessName.ToString() });
                        //save data to the registry
                        try
                        {
                            AddOrUpdateReg(foregroundProcess.ProcessName.ToString(), TotalTicks);
                        }
                        catch (InvalidOperationException)
                        {
                        }
                    }
                    catch (NullReferenceException) { }
                    //Show time!
                    NativeMethods.GetWindowThreadProcessId(ActiveWindowId, out processId);
                    //foregroundProcess containg the name of the current opened window
                    foregroundProcess = Process.GetProcessById(processId);
                    //start the timer for the new opened application
                    StartTick = DateTime.Now.Ticks;
                    //LastWindowId - represent the last opened application id
                    LastWindowId = (int)ActiveWindowId;
                }
                //put the current thread into sleep for 600 milliseconds
                System.Threading.Thread.Sleep(600);
            } while (true);
        }
        #endregion

        #region Instance Cache
        //local data storage
        void AddOrUpdateReg(string key, long value)
        {
            //MessageBox.Show("writte: " + value + " to key: " + key);
            RegKey = Registry.CurrentUser.OpenSubKey(RegLocation, true);
            //here we calculate the old value with the new
            RegKey.SetValue(key, Convert.ToInt32(value) + Convert.ToInt32(RegKey.GetValue(key)), RegistryValueKind.String);
        }
        #endregion

        #region ButtonEvents
        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
        }
        private void OnCloseWindow(object target, ExecutedRoutedEventArgs e)
        {
#if NET4
            Microsoft.Windows.Shell.SystemCommands.CloseWindow(this);
#else
            SystemCommands.CloseWindow(this);
            //save changes in the application settings oc close
            Properties.Settings.Default.Save();
#endif
        }

        private void OnMaximizeWindow(object target, ExecutedRoutedEventArgs e)
        {
#if NET4
            Microsoft.Windows.Shell.SystemCommands.MaximizeWindow(this);
#else
            SystemCommands.MaximizeWindow(this);
#endif
        }

        private void OnMinimizeWindow(object target, ExecutedRoutedEventArgs e)
        {
#if NET4
            Microsoft.Windows.Shell.SystemCommands.MinimizeWindow(this);
#else
            SystemCommands.MinimizeWindow(this);
#endif
        }

        private void OnRestoreWindow(object target, ExecutedRoutedEventArgs e)
        {
#if NET4
            Microsoft.Windows.Shell.SystemCommands.RestoreWindow(this);
#else
            SystemCommands.RestoreWindow(this);
#endif
        }

          private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
          {
              //move the UI
              DragMove();
          }

        #endregion

        #region Methods
          static DateTime GetYesterday()
          {
              // Add -1 to now.
              return DateTime.Today.AddDays(-1);
          }

          private string GetDateFromRegKey(string source)
          {
              int index = source.LastIndexOf("\\");
              return source.Substring(index + 1, source.Length - index - 1);
          }

          internal bool IfSignedIn
          {
              //get { return ValueSource; }
              set
              {
                  Dispatcher.Invoke(new Action(() =>
                  {
                      if (value)
                      {
                          if (!signinatstart)
                          {
                              UserPage _UserPage = new UserPage();
                              PageTransitionControl.ShowPage(_UserPage); 
                          }
                          AccountBtn.Content = TimeCount.Properties.Settings.Default.UserName;
                          signinatstart = false;
                      }
                      else
                      {
                          //show error
                          if (signinatstart == true) { AccountBtn.Content = "Sign in"; signinatstart = false; }
                          Properties.Settings.Default.SignedIn = false;
                          MessageBox.Show("The user name is no valid");
                      }
                  }));
              }
          }
          #endregion
    }
}

#region Another...
//internal string ReturnedMySqlData
//{
//    //get { return ValueSource; }
//    set { Dispatcher.Invoke(new Action(() => { MessageBox.Show(value); })); }
//} 


//List<NavigationBarItems> Items;

//internal void AddNavigationBarItems(string[] LinkName, string[] LinkDescription)
//{

//    Items = new List<NavigationBarItems>();
//    for (int i = 0; i < LinkName.Length; i++)
//    {
//        Items.Add(new NavigationBarItems() { DisplayName = LinkName[i], ToolTipContent = LinkDescription[i] });
//    }
//    //NavigationBar.ItemsSource = Items;
//    //NavigationBar.Visibility = System.Windows.Visibility.Visible;
//}


//this block runs if the user close this app
//protected override void OnClosed(EventArgs e)
//{
//    base.OnClosed(e);
//}

//public delegate void UpdateGUIOutsideFeedbackMessage(string message);

//private void UpdateText(string message)
//{
//    //CurrentProcessName.Text = message;
//}

//The RegLocaton represent the application registry key location
#endregion
