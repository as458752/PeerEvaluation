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
                if (Session["manager"] != null)
                {
                    loginLink.Text = "Logout";
                    loginLink.NavigateUrl = "Logout.aspx";
                    lblWelcome.Text = "Welcome, Manager";
                    lblWelcome.Visible = true;
                }
                else if (Session["UserName"]==null)
                {
                    loginLink.Text = "Login";
                    loginLink.NavigateUrl = "LoginPage.aspx";
                    lblWelcome.Visible = false;
                }
                else
                {
                    loginLink.Text = "Logout";
                    loginLink.NavigateUrl = "Logout.aspx";
                    userName = (string)Session["UserName"];
                    lblWelcome.Text = "Welcome, " + userName;
                    lblWelcome.Visible = true;
                }
                
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (Session["manager"] != null) Response.Redirect("Manager.aspx");
            else if (Session["UserName"] != null)
            {
                if (Session["usertype"].Equals(0)) Response.Redirect("ClassManager.aspx");
                else Response.Redirect("StudentPage.aspx");
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void btnManager_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerLogin.aspx");
        }
    }
}