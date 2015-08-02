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

using TimeCount.Methods;
using TimeCount.ViewModels;
namespace TimeCount.Pages
{
    /// <summary>
    /// Interaction logic for CreateNewUser.xaml
    /// </summary>
    public partial class CreateNewUser : UserControl
    {
      
        public CreateNewUser()
        {
            InitializeComponent();
            // a simple view model for appearance configuration
            this.DataContext = new AccountCreationViewModel();
            SubmitBtn.Click += (o, e) =>
            {
                if (string.IsNullOrEmpty(this.TextFirstName.Text))
                { Keyboard.Focus(this.TextFirstName); return; }
                if (string.IsNullOrEmpty(this.TextLastName.Text))
                { Keyboard.Focus(this.TextLastName); return; }
                if (string.IsNullOrEmpty(this.TextUserName.Text))
                { Keyboard.Focus(this.TextUserName); return; }
                if (string.IsNullOrEmpty(this.TextPassword.Text) || this.TextPassword.Text.Length < 6)
                { Keyboard.Focus(this.TextPassword); return; }
                //Keyboard.Focus(this.TextRepeatPass);
                if (string.IsNullOrEmpty(this.DateBirth.SelectedDate.ToString()))
                { Keyboard.Focus(this.DateBirth); return; }
                if (AgreeCB.IsChecked == true)
                {
                    MySqlDataBase _MySqlDataBase = new MySqlDataBase();
                    _MySqlDataBase.CreateNewUser();
                }
                else
                {
                    AgreeCB.Foreground = Brushes.Green;
                }
            };
            //this.Loaded += (o, e) =>
            //{
            //    Keyboard.Focus(this.TextFirstName);
            //};
        }
    }
}
