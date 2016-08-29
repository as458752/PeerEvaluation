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
    public partial class ResetPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String encryed = Request.QueryString["username"];
            Session["username"] = Encryption.decrypt(encryed,2);
        }

        protected void confirmButton_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("UPDATE [Table] SET Password =" + newPass.Text + "where Email=@email", conn);
            SqlCommand cmd = new SqlCommand("Update [Account] set [Password] = '" + newPass.Text + "'where [username]= '" + username + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('your password has been updated. You will be redirected to login page')</script>");
            //newPass.Text = "";
            newPass.Text = username;
            confirmPass.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }
    }
}