using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//thread library
using System.Threading;
//mysql
using MySql.Data.MySqlClient;

//for the thread 
using TimeCount.Pages;


using System.Reflection;


//reg key namespace
using Microsoft.Win32;
using TimeCount.ViewModels;

//cryptography dynamic link library
using Crypto8;

namespace TimeCount.Methods
{
   public class MySqlDataBase 
    {
        //internal string Link;
      
        static MySqlCommand _MySqlCommand;
        AccountViewModel _AccountViewModel = new AccountViewModel();


        #region private
        static MySqlConnection Connection = new MySqlConnection(Crypto8.Cryptography.Decrypt("OH1UyOm6jJLaz6Wd2fLhTe8ONXWxVYNMPBhp4dJ+EoGYQTuqxQSRIAyD8pjSziFjOqWDS4feLbM2hkqp/yiv0/pRUm7oL+sOs1afR9UPR/zIcH78RImKJg==", true));
        #endregion

           // MessageBox.Show(Crypto8.Cryptography.Encrypt("lol", true) );
          //  MessageBox.Show(Crypto8.Cryptography.Decrypt(Crypto8.Cryptography.Encrypt("lol", true), true));
        internal void SignIn()
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();
            }
            catch (MySqlException)
            {
                //MainPage.main1.ReturnedMySqlConnectionState = false;
                MainWindow.main.IfSignedIn = false;
                return;
            }
            catch (TimeoutException)
            {
                MainWindow.main.IfSignedIn = false;
                return;
            }

            //if (!Connected)  CreateConnection(); 
            //Search for a date : mysql> SELECT * FROM employee WHERE dept = 'TECHNOLOGY' AND salary >= 6000;
            //mysql> SELECT * FROM TimeCounterUsers WHERE UserName = '" + TextUserName.Text + "' AND Password='" + TextPassword.Text + "';"
            using (_MySqlCommand = new MySqlCommand("SELECT * FROM TimeCounterUsers WHERE UserName = '" + _AccountViewModel.UserName + "' AND Password='" + Crypto8.Cryptography.Encrypt(_AccountViewModel.Password, true) + "';", Connection))
            {
                try
                {
                    MySqlDataReader _MySqlDataReader = _MySqlCommand.ExecuteReader();
                    if (_MySqlDataReader.Read())
                    {
                        //save if it is correct to the application settings
                        TimeCount.Properties.Settings.Default.UserName = _AccountViewModel.UserName;
                        TimeCount.Properties.Settings.Default.UserPassword = _AccountViewModel.Password;
                        TimeCount.Properties.Settings.Default.SignedIn = true;
                        TimeCount.Properties.Settings.Default.Save();
                        MainWindow.main.IfSignedIn = true;
                        //if (!TimeCount.Properties.Settings.Default.SignedIn)
                        //{
                        //get the first and last user name from the db by split the source string at `:`
                        //set value of the MainPage SignInBtn
                        //var window2 = System.Windows.Application.Current.Windows.Cast<System.Windows.UIElement>().FirstOrDefault(window => window is UserPage) as UserPage;
                        //window2.UserNameLbl.Content = _MySqlDataReader["UserInformations"].ToString();
                    }
                    else MainWindow.main.IfSignedIn = false;
                    _MySqlDataReader.Dispose();
                }
                catch (MySqlException)
                {
                    MainWindow.main.IfSignedIn = false;
                }
                //disp.
                _MySqlCommand.Dispose();
            }  
        }

       public void CreateNewUser()
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();
                int i;
            }
            catch (MySqlException)
            {
                return;
            }
            catch (TimeoutException)
            {
                return;
            }

           //initialize the class for the new user informations
            AccountCreationViewModel _AccountCreationViewModel = new AccountCreationViewModel();
            //create the user table
            //string new_table = string.Concat("CREATE TABLE `" + _AccountCreationViewModel.UserName + "` (" +
            //    "`UserName` VARCHAR(255)," +
            //    "`Password` VARCHAR(255));");
            //"`Password` VARCHAR(255));");
            //"`Password` VARCHAR(255));");
            //"`Password` VARCHAR(255));");
           //ERROR MEANS THAT THIS USER EXIST
          
            //using (_MySqlCommand = new MySqlCommand(new_table, Connection)) _MySqlCommand.ExecuteNonQuery();
            string UserInformation = string.Concat("First name: " + _AccountCreationViewModel.FirstName  +
                                                     ":Last name: " + _AccountCreationViewModel.LastName  +
                                                        ":Birth day: " + _AccountCreationViewModel.BirthDay );

            //writte the user informations in the TimeCounterUsers table
            //if no error appear, we writte the user informations to the database
            using (_MySqlCommand = new MySqlCommand("INSERT INTO TimeCounterUsers (UserName, Password, UserInformations) VALUES('" + _AccountCreationViewModel.UserName + "', '" + Crypto8.Cryptography.Encrypt(_AccountCreationViewModel.Password, true) + "', '" + UserInformation + "')", Connection))
            {
                _MySqlCommand.ExecuteNonQuery();
            }
            _MySqlCommand.Dispose();
            //create a table to store data 
            string new_table = string.Concat("CREATE TABLE `" + _AccountViewModel.UserName + "` (" +
                "`Date` VARCHAR(255)," +
                "`Progress` VARCHAR(255));");
            using (_MySqlCommand = new MySqlCommand(new_table, Connection))
            {
                _MySqlCommand.ExecuteNonQuery();
                _MySqlCommand.Dispose();
            }
            //sign in directly
            //save if it is correct to the application settings
            TimeCount.Properties.Settings.Default.UserName = _AccountViewModel.UserName;
            TimeCount.Properties.Settings.Default.UserPassword = _AccountViewModel.Password;
            TimeCount.Properties.Settings.Default.SignedIn = true;
            TimeCount.Properties.Settings.Default.Save();
            // sign in to the new user
            MainWindow.main.IfSignedIn = true;
        }

       private bool IsDataFound { get; set; }

       public void GetMySqlData()
       {
           try
           {
               if (Connection.State != System.Data.ConnectionState.Open)
                   Connection.Open();
           }
           catch (MySqlException)
           {

               return;
           }
           catch (TimeoutException)
           {
               return;
           }
           //Search for a date
           using (_MySqlCommand = new MySqlCommand("SELECT * FROM " + _AccountViewModel.UserName + " WHERE Date='" + _AccountViewModel.Date + "'", Connection))
           {
               //MySqlDataReader rdr = null;
               MySqlDataReader _MySqlDataReader;
               try
               {
                   IsDataFound = false;
                     _MySqlDataReader = _MySqlCommand.ExecuteReader();
                     while (_MySqlDataReader.Read())
                     {
                         MainPage.main1.ReturnedMySqlData = _MySqlDataReader["Progress"].ToString();
                         IsDataFound = true;
                     }
                     if(!IsDataFound) MainPage.main1.ReturnedMySqlData = "no data found";
                     _MySqlDataReader.Dispose();
               }
               catch (MySqlException)
               {
                   MainPage.main1.ReturnedMySqlData = "no data found";
               }
               _MySqlCommand.Dispose();
           }
       }

       public void WritteData(string RegLocation, string sourceDate)
       {
           try
           {
               if (Connection.State != System.Data.ConnectionState.Open)
                   Connection.Open();
           }
           catch (MySqlException)
           {
           //    //on error, we writte it to the application setting, and in an another time if no error appear we writte it
           //    //TimeCount.Properties.Settings.Default.InBearbeitung.Add(RegLocation);
           //    //exit statement
               return;
           }
           catch (TimeoutException)
           {
               //on error, we writte it to the application setting, and in an another time if no error appear we writte it
               //TimeCount.Properties.Settings.Default.InBearbeitung.Add(RegLocation);
               //exit statement
               return;
           }
           //if (Properties.Settings.Default.SignedIn == true)
           //{
           //    //if there are loged in, then get all the wanted data
           //}
          
          
           
           string DataToMysql = string.Empty;
           //string SerchedDate = DateTime.Now.ToString("d");
           foreach (string aplicatie in Registry.CurrentUser.OpenSubKey(RegLocation, true).GetValueNames())
           {
               DataToMysql += aplicatie.ToString() + "|" + Convert.ToInt32(Registry.CurrentUser.OpenSubKey(RegLocation, true).GetValue(aplicatie)) + Environment.NewLine;
           }

           using ( _MySqlCommand = new MySqlCommand("INSERT INTO " + _AccountViewModel.UserName + " (Date, Progress) VALUES('" + sourceDate + "', '" + DataToMysql + "')", Connection))
           {
               _MySqlCommand.ExecuteNonQuery();
               _MySqlCommand.Dispose();
           }


           TimeCount.Properties.Settings.Default.LastWrittedDate = RegLocation;
           TimeCount.Properties.Settings.Default.Save();
           return;
       }

    }
}

//public void CreateMyretSqlConn()
// {
//     if (Properties.Settings.Default.SignedIn == true)
//     {
//         //if there are loged in, then get all the wanted data
//     }


//     //create a table if it does not exist
//     string new_table = string.Concat("CREATE TABLE IF NOT EXISTS `StyleSSilviu` (" +
//         "`Date` VARCHAR(255)," +
//         "`Progress` VARCHAR(255));");
//     using (_MySqlCommand = new MySqlCommand(new_table, Connection)) { _MySqlCommand.ExecuteNonQuery(); _MySqlCommand.Dispose(); }

//     //save all data to the database
//     string RegLocation = "SOFTWARE\\TimeCount\\" + DateTime.Now.Month + "\\" + DateTime.Now.ToString("d");
//     string DataToMysql = string.Empty;

//     //string SerchedDate = DateTime.Now.ToString("d");
//     string SerchedDate = "lol";
//     foreach (string aplicatie in Registry.CurrentUser.OpenSubKey(RegLocation, true).GetValueNames())
//     {
//         DataToMysql += aplicatie.ToString() + "|" + Convert.ToInt32(Registry.CurrentUser.OpenSubKey(RegLocation, true).GetValue(aplicatie)) + Environment.NewLine;
//     }
//     using (_MySqlCommand = new MySqlCommand("INSERT INTO " + _AccountViewModel.UserName + " (Date, Progress) VALUES('" + DateTime.Now.ToString("d") + "', '" + DataToMysql + "')", Connection))
//     {
//         _MySqlCommand.ExecuteNonQuery();
//         _MySqlCommand.Dispose();
//     }

//     //Search for a date
//     using (_MySqlCommand = new MySqlCommand("select * from " + _AccountViewModel.UserName + " where Date='" + SerchedDate + "';", Connection))
//     {
//         //MySqlDataReader rdr = null;
//         MySqlDataReader _MySqlDataReader = _MySqlCommand.ExecuteReader();


//         while (_MySqlDataReader.Read())
//         {

//             //MessageBox.Show(_MySqlDataReader["Progress"].ToString());

//         }
//     }
// }
//using (_MySqlCommand = new MySqlCommand("select * from TimeCounterUsers where Date='" + SerchedDate + "';", Connection))
//{
//    //MySqlDataReader rdr = null;
//    MySqlDataReader _MySqlDataReader = _MySqlCommand.ExecuteReader();


//    while (_MySqlDataReader.Read())
//    {

//        //MessageBox.Show(_MySqlDataReader["Progress"].ToString());

//    }
//}

/// <summary>
/// Get the date from database by the date
/// </summary>




//private string SignedIn
//{
//    get { return signedin; }
//    set { signedin = value; }
//}

//public bool Connected { get; set; }

//chech if the connection state is changed
//void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
//{
//    if (Connection.State == System.Data.ConnectionState.Closed) Connected = false;
//}

//private bool ConnectionState()
//{
//    if (Connection.State == System.Data.ConnectionState.Closed)
//     {
//         try
//         {
//             Connection.Open();
//             return true;
//             // Connection.StateChange += Connection_StateChange;
//         }
//         catch (MySqlException)
//         {
//             return false;
//         }
//     }
//    return false;
//}