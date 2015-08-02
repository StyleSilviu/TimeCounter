using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


 using TimeCounter_WEB_.Methods;

using TimeCounter_WEB_.ViewModels;

namespace TimeCounter_WEB_.Pages
{
    public partial class SignIn : System.Web.UI.Page
    {
        MySqlDB _MySqlDB = new MySqlDB();
        //UserAccountViewModel _UserAccountViewModel = new UserAccountViewModel();


        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            //_UserAccountViewModel.UserName = ;
            //_UserAccountViewModel.Password = ;
            //_UserAccountViewModel.Password = ;


            if (_MySqlDB.SignIn(txtUseName.Text, txtPass.Text))
            {
                Response.Redirect("/Pages/Home.aspx");
            }
            else txtStatus.Text = "User not valid";
        }

    }
}