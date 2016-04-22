using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PeerEvaluation
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [Account] where [UserName]='" + TextBoxUN.Text + "'";
            string checkemail = "select count(*) from [Account] where [Email]='" + TextBoxEmail.Text + "'";
            string checkASUID = "select count(*) from [Account] where [ASU ID]='" + TextBoxASUID.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            SqlCommand com2 = new SqlCommand(checkemail, conn);
            SqlCommand com3 = new SqlCommand(checkASUID, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            int temp1 = Convert.ToInt32(com2.ExecuteScalar().ToString());
            int temp2 = Convert.ToInt32(com3.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                Response.Write("Username already exists.");
            }
            else if (temp1 == 1)
            {
                Response.Write("Email already exists.");
            }
            else if (temp2 == 1)
            {
                Response.Write("ASU ID already exists.");
            }
            else
            {
                try
                {
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                    conn1.Open();
                    String type = "";
                    if (DropDownList1.SelectedIndex == 0) type = "Forms";
                    else type = "Professor";
                    string checkQuery = "select count(*) from [" + type + "] where [ASU ID] ='" + TextBoxASUID.Text + "'";
                    SqlCommand com4 = new SqlCommand(checkQuery, conn1);
                    int temp3 = Convert.ToInt32(com4.ExecuteScalar().ToString());
                    if (temp3 == 0)
                    {
                        Response.Write("Not Authorized!");
                        return;
                    }
                    string insertQuery = "insert into [Account] ([ASU ID],[Username],[Email],[Password]) values (@ASUID,@Uname,@email,@password)";
                    SqlCommand com1 = new SqlCommand(insertQuery, conn1);
                    com1.Parameters.AddWithValue("@Uname", TextBoxUN.Text);
                    com1.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                    com1.Parameters.AddWithValue("@password", TextBoxPass.Text);
                    com1.Parameters.AddWithValue("@ASUID", TextBoxASUID.Text);

                    com1.ExecuteNonQuery();
                    Response.Write("Registration is successful.");

                    conn1.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.ToString());
                }
            }
        }
    }
}