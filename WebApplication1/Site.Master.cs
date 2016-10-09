using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userName;
                if (Session["UserName"]==null)
                {
                    loginLink.Visible = true;
                    lblWelcome.Visible = false;
                }
                else
                {
                    loginLink.Visible = false;
                    userName = (string)Session["UserName"];
                    lblWelcome.Text = "Welcom, " + userName;
                    lblWelcome.Visible = true;
                }
                
            }
        }
    }
}