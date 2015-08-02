using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCount.ViewModels
{
    public class AccountViewModel
    {
         private static string date;
         private static bool connection;
         private static string username;
         private static string password;

        internal string UserName
        {
            get { return username; }
            set { username = value; }
        }

        internal bool IsConnected
        {
            get { return connection; }
            set { connection = value; }
        }

        internal string Date
        {
            get { return date; }
            set { date = value; }
        }

        internal string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
