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


//thread library
using System.Threading;

//for the page transition
using TimeCount;
using TimeCount.Methods;
using TimeCount.ViewModels;
namespace TimeCount.Pages
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        MySqlDataBase _MySqlDataBase = new MySqlDataBase();
        AccountViewModel _AccountViewModel = new AccountViewModel();

        public SignIn()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            { MessageBox.Show("no internet connection found!"); return; }
          _AccountViewModel.UserName = TextUserName.Text;
          _AccountViewModel.Password = TextPassword.Password;

          //open the mysql class on an another thread to make the UI faster
          Thread _Thread = new Thread(delegate()
          {
              _MySqlDataBase.SignIn();
          });
          _Thread.Start();
          Status.Content = "Sign in, please wait...";
       }

        private void TextUserName_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TextUserName.Text == "User name") TextUserName.Clear();
            //remove event
            TextUserName.MouseEnter -= TextUserName_MouseEnter;
        }

        private void TextPassword_MouseEnter(object sender, MouseEventArgs e)
        {
           TextPassword.Password = string.Empty;
            //remove event
            TextPassword.MouseEnter -= TextPassword_MouseEnter;
        }
        
        //internal string ReturnThreadMySqlStatus
        //{
        //    //get { return ValueSource; }
        //    set { Dispatcher.Invoke(new Action(() => { Status.Content = value; })); }
        //}
   } 
}

