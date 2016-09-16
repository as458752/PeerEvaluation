using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation
{
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userName = (string)Session["UserName"];
                lblWelcome.Text = "Welcome, " + userName;
                updateClassList();
            }
        }

        protected void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstClassForms.Items.Clear();
            // Select existing class data
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string getDataQuery = "select [FormName] from [ClassFormConnection] where[ClassName] = '" + lstClasses.SelectedItem.Text + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                string className;
                while (reader.Read())
                {
                    className = reader.GetString(0);
                    lstClassForms.Items.Add(className);
                }
            }
        }

        protected void lstClassForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void updateClassList()
        {
            lstClasses.Items.Clear();
            // Select existing class data
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string getDataQuery = "select [ClassName] from [Groups] where[ASU ID] = '" + Session["ASU ID"].ToString() + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                string className;
                while (reader.Read())
                {
                    className = reader.GetString(0);
                    lstClasses.Items.Add(className);
                }
            }
            reader.Close();
            conn.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["ASU ID"] = null;
            Response.Redirect("StudentLogin.aspx");
        }

        protected void btnFillForm_Click(object sender, EventArgs e)
        {
            Session["FormName"] = lstClassForms.SelectedItem.Text;
            Session["ClassName"] = lstClasses.SelectedItem.Text;
            Response.Redirect("FormFiller.aspx");
        }
    }
}