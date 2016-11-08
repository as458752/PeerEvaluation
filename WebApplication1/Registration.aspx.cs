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
            int numUsers = Convert.ToInt32(com.ExecuteScalar().ToString());
            int numEmails = Convert.ToInt32(com2.ExecuteScalar().ToString());
            int numIDs = Convert.ToInt32(com3.ExecuteScalar().ToString());
            conn.Close();
            if (numUsers == 1)
            {
                lblError.Text = "Username already exists.";
                return;
            }
            if (numEmails == 1)
            {
                lblError.Text = "Email already exists.";
                return;
            }
            if (numIDs == 1)
            {
                // The ASU ID is already in the database, which means either the professor
                // registered it, or the user is trying to register an already registered ASU ID
                conn.Open();
                // Check whether the ASU ID is registered or not
                string checkRegistered = "select count(*) from [Account] where [ASU ID]='" + TextBoxASUID.Text + "' and [Registered]='1'";
                SqlCommand checkRegComm = new SqlCommand(checkRegistered, conn);
                bool registered = int.Parse(checkRegComm.ExecuteScalar().ToString()) == 1;
                conn.Close();
                if (registered)
                {
                    // The user is trying to register an already registered ASU ID: error
                    lblError.Text = "ASU ID already exists";
                    return;
                } else
                {
                    // Finally a legal case: the ASU ID is in the database, authorized by the
                    // Professor, so what's left is for the student to fill in the rest of the data
                    try
                    {
                        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                        conn1.Open();
                        string insertQuery = "update [Account] set [Username]=@Uname,[Email]=@email,[Password]=@password,[Registered]='1' where [ASU ID]=@ASUID";
                        SqlCommand com1 = new SqlCommand(insertQuery, conn1);
                        com1.Parameters.AddWithValue("@Uname", TextBoxUN.Text);
                        com1.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                        com1.Parameters.AddWithValue("@password", TextBoxPass.Text);
                        com1.Parameters.AddWithValue("@ASUID", TextBoxASUID.Text);

                        com1.ExecuteNonQuery();

                        conn1.Close();
                        Response.Redirect("RegistrationSuccessful.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error: " + ex.ToString();
                    }

                }
            }
            else
            {
                // The specified ASU ID is not in the database, so the Professor
                // hasn't yet authorized the student
                lblError.Text = "The specified ASU ID has not been authorized for registration.";
            }
        }
    }
}