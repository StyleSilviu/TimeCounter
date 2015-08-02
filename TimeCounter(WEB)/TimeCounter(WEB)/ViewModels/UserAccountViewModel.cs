using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeCounter_WEB_.ViewModels
{
    public class UserAccountViewModel
    {
        private static bool issignedin;
        private static string username;
        private static string password;


        internal bool isSignedIn
        {
            get { return issignedin; }
            set { issignedin = value; }
        }

        internal string UserName
        {
            get { return username; }
            set { username = value; }
        }

        internal string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}