//author: Jing Liang
//date: 3/31/2016

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation
{
    public partial class ManagerLogin : System.Web.UI.Page
    {
        private static string username = "admin";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string line;
            string fileLoc = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\managerPassword.txt");
            System.IO.StreamReader file = new System.IO.StreamReader(fileLoc);
            if ((line = file.ReadLine()) != null)
            {
                file.Close();
                line = Encryption.decrypt(line,4);
                if (txtUsername.Text == username && txtPassword.Text == line)
                {
                    Session["manager"] = true;
                    Response.Redirect("Manager.aspx");
                }
                else
                {
                    lblError.Text = "Login Information is incorrect!";
                    
                }
            }
            else
            {
                file.Close();
                lblError.Text = "System file is damaged!";
            }
            lblError.Visible = true;
        }
    }
}