using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TimeCounter_WEB_.Methods;

using TimeCounter_WEB_.ViewModels;

using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace TimeCounter_WEB_.Pages
{
    public partial class Home : System.Web.UI.Page
    {

        MySqlDB _MySqlDB = new MySqlDB();
       // UserAccountViewModel _UserAccountViewModel = new UserAccountViewModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            //put row in the pie chart
            _objdt.Columns.Add("Software", typeof(string));
            _objdt.Columns.Add("Growth", typeof(long));
            //ascunde label
            this.Chart1.Series[0]["PieLabelStyle"] = "Disabled";
   
        }

        private string FormatConverter(string sourceNumber)
        {
            if(sourceNumber.Length == 2)
            {
             return sourceNumber; 
            }
            else return "0" + sourceNumber;
            return string.Empty;
        }

        DataRow _objrow;
        DataTable _objdt = new DataTable();
        int ReturnedSeconds, TotalSec, itemCount;

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            string date = FormatConverter(Calendar.SelectedDate.Day.ToString()) + "." + FormatConverter(Calendar.SelectedDate.Month.ToString()) + "." + Calendar.SelectedDate.Year.ToString();
            
            string returnedContent = _MySqlDB.GetMyqlData(date);

            if (!string.IsNullOrEmpty(returnedContent))
            {
                //initialize chart
                ReturnedSeconds = TotalSec = itemCount = 0;
                foreach (string Item in returnedContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //split the string value at "|"
                    var parts = Item.Split(new char[] { '|' });
                    //MessageBox.Show("app: " + parts[0] + " value: " + parts[1]);
                    //parts[0] - represend the app name
                    //parts[1] - represent the total spenden time in string, but we convert it in to int32
                    ReturnedSeconds = Convert.ToInt32(parts[1]);

                    _objrow = _objdt.NewRow();

                    itemCount++;

                    _objrow["Software"] = itemCount + ". " + parts[0].ToString() + " (" + TimeSpan.FromSeconds(Convert.ToInt32(ReturnedSeconds)).ToString() + ")";

                    _objrow["Growth"] = ReturnedSeconds;

                    _objdt.Rows.Add(_objrow);

                    TotalSec += ReturnedSeconds;

                }


                Label4.Text = "Total spended time in this day: " + TimeSpan.FromSeconds(TotalSec).ToString();


                Chart1.DataSource = _objdt;
                Chart1.DataBind();
            }
            else
            {
                Label4.Text = "No data found at this date";
                Label4.Text = string.Empty;
            }
        }
        



    }
}