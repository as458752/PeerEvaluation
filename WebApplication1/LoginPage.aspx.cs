using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string userName = TextBoxUserName.Text;
            string checkuser = "select count(*) from [Account] where [UserName]='" + userName + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                string checkPasswordQuery = "select [Password] from [Account] where [UserName]='" + TextBoxUserName.Text + "'";
                SqlCommand comm = new SqlCommand(checkPasswordQuery, conn);
                string password = comm.ExecuteScalar().ToString().Replace(" ", "");

                if (password == TextBoxPassword.Text)
                {
                    string getDataQuery = "select [ASU ID],[UserType] from[Account] where[UserName] = '" + TextBoxUserName.Text + "'";
                    comm = new SqlCommand(getDataQuery, conn);
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Session["UserName"] = userName;
                        reader.Read();
                        Session["ASU ID"] = reader.GetString(0);
                        int userType = reader.GetInt32(1);
                        Response.Write("Information is correct");
                        if (userType == 0)
                        {
                            Session["usertype"] = 0;
                            Response.Redirect("ClassManager.aspx");
                        }
                        else if (userType == 1)
                        {
                            Session["usertype"] = 1;
                            Response.Redirect("StudentPage.aspx");
                        }

                    }
                    else
                    {
                        lblErrorMessage.Text = "The user name is not registered.";
                    }
                    reader.Close();
                }
                else
                {
                    lblErrorMessage.Text = "Password is not correct";
                }
                conn.Close();
            }
            else
            {
                lblErrorMessage.Text = "Username is not correct";
            }
            lblErrorMessage.Visible = true;
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            string username = string.Empty;
            string password = string.Empty;
            Session["email"] = txtEmail.Text;
            string constr = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Username, [Password] FROM [Account] WHERE Email = @Email"))
                {
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            username = sdr["Username"].ToString().Trim();
                            password = sdr["Password"].ToString().Trim();
                        }
                    }
                    con.Close();
                }
            }
            if (!string.IsNullOrEmpty(password))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Hi " + username + ", <br /> Click on below given link to Reset Your Password <br />");
                string encryed = Encryption.encrypt(username, 2);
                sb.Append("<a href=http://localhost:5766/ResetPasswordPage.aspx?username=" + encryed);
                sb.Append(">Click here to change your password</a> <br/>");
                sb.Append("<br /> Thanks");
                MailMessage mm = new System.Net.Mail.MailMessage("javaemailsender@gmail.com", txtEmail.Text.Trim(), "Password Recovery", sb.ToString());
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "javaemailsender@gmail.com";
                NetworkCred.Password = "sendtestemail";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                mm.IsBodyHtml = true;
                smtp.Send(mm);
                msgLabel.ForeColor = Color.Green;
                msgLabel.Text = "Password has been sent to your email address.";
            }
            else
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "This email address does not match our records.";
                msgLabel.Visible = true;
            }
        }
    }
}