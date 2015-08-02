using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// for the NotifyPropertyChanged event
using TimeCount.Presentation;
//IDataErrorInfo
using System.ComponentModel;
namespace TimeCount.ViewModels
{
    class AccountCreationViewModel : NotifyPropertyChanged, IDataErrorInfo
    {
         private static string firstName;
         private static string lastName;
         private static string password;
         private static string birthday;
         private static string userName;
         //private string repeatPass;
         private string[] warning = { "Required", "Too shorter pass" };


        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;

                    OnPropertyChanged("UserName");
                }
            }
        }

        public string BirthDay
        {
            get { return birthday; }
            set
            {
                if (birthday != value)
                {
                    birthday = value;

                    OnPropertyChanged("Birthday");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;

                    OnPropertyChanged("Password");
                }
            }
        }

        //public string RepeatPass
        //{
        //    get { return this.repeatPass; }
        //    set
        //    {
        //        if (this.repeatPass != value)
        //        {
        //            this.repeatPass = value;

        //            OnPropertyChanged("RepeatPass");
        //        }
        //    }
        //}

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;

                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName")
                {
                    return string.IsNullOrEmpty(firstName) ? warning[0] : null;
                }
                if (columnName == "LastName")
                {
                    return string.IsNullOrEmpty(lastName) ? warning[0] : null;
                }
                if (columnName == "UserName")
                {
                    return string.IsNullOrEmpty(userName) ? warning[0] : null;
                }
                if (columnName == "Password")
                {
                    if (!string.IsNullOrEmpty(password)) return password.Length < 6 ? warning[1] : null;  
                }
                //if (columnName == "RepeatPass")
                //{
                //    return string.IsNullOrEmpty(this.repeatPass) ? "Required" : null;
                //}
                return null;
            }
        }
    }
}
