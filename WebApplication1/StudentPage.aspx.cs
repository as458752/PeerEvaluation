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
            if (Session["UserName"] == null) Response.Redirect("LoginPage.aspx");
            if (!IsPostBack)
            {
                string userName = (string)Session["UserName"];
                //lblWelcome.Text = "Welcome, " + userName;
                updateClassList();
            }
        }

        protected void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {     
            lstClassForms.Items.Clear();
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string getDataQuery = "select [FormName] from [ClassFormConnection] where[ClassName] = '" + lstClasses.SelectedItem.Text + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            List<string> classForms = new List<string>();
            
            // First check if there are forms associated with the class
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    classForms.Add(reader.GetString(0));
                }                
            }
            reader.Close();

            // If there are forms, check if there are peers to be evaluated
            if(classForms.Count > 0) {
                // Get the group number in the given class
                getDataQuery = "select [GroupNumber] from [Groups] where[ASU ID] = '" + Session["ASU ID"].ToString() + "' and [ClassName] = '" + lstClasses.SelectedItem.Text + "'";
                comm = new SqlCommand(getDataQuery, conn);
                reader = comm.ExecuteReader();
                int groupNumber = 0;
                if (reader.HasRows) {
                    while (reader.Read()) {
                        groupNumber = reader.GetInt32(0);
                    }
                }
                reader.Close();

                // For each form in the class, check if there are peers
                foreach (String formName in classForms) {
                    getDataQuery = "select * from [Account] join [Groups] on [Account].[ASU ID]=[Groups].[ASU ID] where [Groups].[GroupNumber]=" + groupNumber + " and [Groups].[ASU ID] <> '" + Session["ASU ID"].ToString() + "' and [Groups].[ClassName]='" + lstClasses.SelectedItem.Text + "' and [Account].[ASU ID] not in (select [PeerID] from [FormsAnswers] where [ASU ID]='" + Session["ASU ID"].ToString() + "')";
                    comm = new SqlCommand(getDataQuery, conn);
                    reader = comm.ExecuteReader();
                    if (reader.HasRows) {
                        lstClassForms.Items.Add(formName);
                    }
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

        protected void btnFillForm_Click(object sender, EventArgs e)
        {
            if(lstClassForms.SelectedItem != null) {
                Session["FormName"] = lstClassForms.SelectedItem.Text;
                Session["ClassName"] = lstClasses.SelectedItem.Text;
                Response.Redirect("FormFiller.aspx");
            } else {
                lblMessage.Text = "You must select a form first.";
            }
            
        }
    }
}