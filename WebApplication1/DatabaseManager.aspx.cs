using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation
{
    public partial class DatabaseManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String companyName = GridView2.SelectedRow.Cells[1].Text;

            // Display company name selected by the user.
            TextBox1.Text = "You selected " + companyName + ".";
        }

    }
}