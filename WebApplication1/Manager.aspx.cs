using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string fLocation;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["manager"] == null)
            {
                Response.Redirect("ManagerLogin.aspx");
            }
            else
            {
                fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\professor.txt");
                if (!IsPostBack)
                {
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(fLocation);
                    string[] lines = System.IO.File.ReadAllLines(fLocation);
                    while ((line = file.ReadLine()) != null)
                    {
                        ListBox1.Items.Add(line);
                    }
                    file.Close();
                }
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int idx = ListBox1.SelectedIndex;
            ListBox1.Items.RemoveAt(idx);
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(fLocation);
            foreach (var item in ListBox1.Items)
            {
                SaveFile.WriteLine(item);
            }

            SaveFile.Close();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string spaces = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            spaces = Server.HtmlDecode(spaces);
            string newLine = txtName.Text + spaces + txtId.Text;
            ListBox1.Items.Add(newLine);
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(fLocation);
            foreach (var item in ListBox1.Items)
            {
                SaveFile.WriteLine(item);
            }
            SaveFile.Close();
            txtName.Text = String.Empty;
            txtId.Text = String.Empty;
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            if(txtPasswordOld.Text == "" || txtPasswordNew.Text == "" || txtPasswordConfirm.Text == "") lblResult.Text = "Password can not be empty!";
            else
            {
                if (txtPasswordNew.Text != txtPasswordConfirm.Text) lblResult.Text = "New passwords do not match!";
                else
                {
                    string line;
                    string fileLoc = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\managerPassword.txt");
                    System.IO.StreamReader file = new System.IO.StreamReader(fileLoc);
                    if ((line = file.ReadLine()) != null)
                    {
                        file.Close();
                        line = Encryption.decrypt(line, 4);
                        if (txtPasswordOld.Text != line) lblResult.Text = "Old passwords do not match!";
                        else
                        {
                            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(fileLoc);
                            SaveFile.WriteLine(Encryption.encrypt(txtPasswordNew.Text,4));
                            lblResult.Text = "Password has been changed!";
                            SaveFile.Close();
                        }
                    }
                    else
                    {
                        lblResult.Text = "System file is damaged!";
                        file.Close();
                    }
                }
            }
            lblResult.Visible = true;
        }

        
    }
}