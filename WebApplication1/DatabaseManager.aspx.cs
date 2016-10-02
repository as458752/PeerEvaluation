using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace PeerEvaluation
{
    public partial class DatabaseManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Part p1 = new Part { score="2" };
            Part p2 = new Part { score = "4" };
            Part[] ps = { p1,p2 };
            Result re = new Result { parts = ps };
            XMLUtility.storeResult("1", "", "", "", "", false, "", re);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string getDataQuery = "select [Result] from[Results] where[FormId] = '1'";

            List<Result> re = XMLUtility.getResult(getDataQuery);
            
            TextBox1.Text = re[0].parts[0].score;
        }
    }
}