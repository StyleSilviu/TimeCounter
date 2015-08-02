using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

using Crypto8;

using TimeCounter_WEB_.ViewModels;


namespace TimeCounter_WEB_.Methods
{
    public class MySqlDB
    {
        private bool IsDataFound = false;
        MySqlCommand _MySqlCommand;
        MySqlDataReader _MySqlDataReader;
        UserAccountViewModel _UserAccountViewModel = new UserAccountViewModel();
        
        

        static MySqlConnection Connection = new MySqlConnection(Crypto8.Cryptography.Decrypt("OH1UyOm6jJLaz6Wd2fLhTe8ONXWxVYNMPBhp4dJ+EoGYQTuqxQSRIAyD8pjSziFjOqWDS4feLbM2hkqp/yiv0/pRUm7oL+sOs1afR9UPR/zIcH78RImKJg==", true));

        private void Disp()
        {
            _MySqlDataReader.Dispose();
            _MySqlCommand.Dispose();
        }


        public string GetMyqlData(string sourceDate)
        {
//try
            //{
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();
            //}
            //catch (MySqlException)
            //{
            //    return null;
            //}
            //catch (TimeoutException)
            //{
            //    return null;
            //}
            //Search for a date
            using (_MySqlCommand = new MySqlCommand("SELECT * FROM " + _UserAccountViewModel.UserName + " WHERE Date='" + sourceDate + "'", Connection))
            {
                try
                {
                    IsDataFound = false;
                    _MySqlDataReader = _MySqlCommand.ExecuteReader();
                    while (_MySqlDataReader.Read())
                    {
                        IsDataFound = true;
                        string received = _MySqlDataReader["Progress"].ToString();
                        Disp();
                        return received;
                    }
                    Disp();
                    if (!IsDataFound) return null;


                }
                catch (MySqlException)
                {

                    return null;
                }
           
            }
            return null;
        }


        public bool SignIn(string userName, string pass)
        {
            try
            {
                if (Connection.State != System.Data.ConnectionState.Open)
                    Connection.Open();
            }
            catch (MySqlException)
            {
                //MainPage.main1.ReturnedMySqlConnectionState = false;

                return false;
            }
            catch (TimeoutException)
            {

                return false;
            }

            //if (!Connected)  CreateConnection(); 
            //Search for a date : mysql> SELECT * FROM employee WHERE dept = 'TECHNOLOGY' AND salary >= 6000;
            //mysql> SELECT * FROM TimeCounterUsers WHERE UserName = '" + TextUserName.Text + "' AND Password='" + TextPassword.Text + "';"

            using (_MySqlCommand = new MySqlCommand("SELECT * FROM TimeCounterUsers WHERE UserName = '" + userName + "' AND Password='" + Crypto8.Cryptography.Encrypt(pass, true) + "';", Connection))
            {
                try
                {
                    _MySqlDataReader = _MySqlCommand.ExecuteReader();
                    if (_MySqlDataReader.Read())
                    {
                        _UserAccountViewModel.UserName = userName;
                        _UserAccountViewModel.isSignedIn = true;
                        //disp.
                        Disp();
                         return true;
                    }
                    //disp.
                    Disp();
                }
                catch (MySqlException)
                {
                    Disp();
                    _UserAccountViewModel.isSignedIn = false;
                    return false;
                }
               
            }
            return false;
        }

    }
}