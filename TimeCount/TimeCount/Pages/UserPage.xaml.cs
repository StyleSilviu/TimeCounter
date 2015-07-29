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

namespace TimeCount.Pages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : UserControl
    {
        public UserPage()
        {
            InitializeComponent();
            UserNameLbl.Content = TimeCount.Properties.Settings.Default.UserName;
        }

        private void SignOutBtn_Click(object sender, RoutedEventArgs e)
        {
            //TimeCount.Properties.Settings.Default.UserName = TimeCount.Properties.Settings.Default.UserPassword = string.Empty;
            TimeCount.Properties.Settings.Default.SignedIn = false;
            TimeCount.Properties.Settings.Default.Save();
            //set value of the MainPage SignInBtn
            var window2 = Application.Current.Windows.Cast<Window>().FirstOrDefault(window => window is MainWindow) as MainWindow;
            //reference the control
            window2.AccountBtn.Content = "Sign in";
            window2.PageTransitionControl.ShowPage(new MainPage());
        }
    }
}
