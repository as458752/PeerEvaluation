using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PeerEvaluation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["manager"] == null) Response.Redirect("ManagerLogin.aspx");
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string checkPasswordQuery = "insert into [Account] ([ASU ID], [FullName], [UserType]) values (@asuID, @fullName,0)";
            SqlCommand command = new SqlCommand(checkPasswordQuery, conn);
            command.Parameters.AddWithValue("@asuID", txtId.Text);
            command.Parameters.AddWithValue("@fullName", txtName.Text);
            command.ExecuteScalar();
            conn.Close();
            GridView1.DataBind();
            txtId.Text = "";
            txtName.Text = "";
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = GridView1.SelectedRow.Cells[0].Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string checkPasswordQuery = "delete from [Professor] where [ASU ID]='" + id + "'";
            SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
            passComm.ExecuteScalar();
            conn.Close();
            GridView1.DataBind();
        }

        
    }
}