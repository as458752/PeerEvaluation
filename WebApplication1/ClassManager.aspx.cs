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
    public partial class ClassManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userName = (string)Session["UserName"];
                lblWelcome.Text = "Welcome, " + userName;
                updateClassList();
                updateFormsDropDown();
            }
        }

        private void updateFormsDropDown()
        {
            drpFormsList.Items.Clear();
            drpFormsList.Items.Add("Select a form to add...");
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string getDataQuery = "select distinct [FormName] from[FormsQuestions] where[CreatorID] = '" + Session["ASU ID"].ToString() + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    drpFormsList.Items.Add(reader.GetString(0));
                }
            }
        }

        protected void btnCreateClass_Click(object sender, EventArgs e)
        {
            if (txtClassName.Text != "") {
                // Insert class data
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into [Classes] ([Name],[CreatorID]) values (@Name,@CreatorID)";
                SqlCommand comm = new SqlCommand(insertQuery, conn);
                comm.Parameters.AddWithValue("@Name", txtClassName.Text);
                comm.Parameters.AddWithValue("@CreatorID", Session["ASU ID"].ToString());
                comm.ExecuteNonQuery();
                conn.Close();
                txtClassName.Text = "";
                updateClassList();
            }
        }

        private void updateClassList()
        {
            lstClasses.Items.Clear();
            // Select existing class data
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string getDataQuery = "select [Name] from[Classes] where[CreatorID] = '" + Session["ASU ID"].ToString() + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstClasses.Items.Add(reader.GetString(0));
                }
            }
        }

        protected void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteClass.Enabled = true;

            updateClassForms();
        }

        private void updateClassForms()
        {
            lstClassForms.Items.Clear();

            string className = lstClasses.SelectedItem.Text;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string getDataQuery = "select [FormName] from[ClassFormConnection] where[ClassName] = '" + className + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lstClassForms.Items.Add(reader.GetString(0));
                }
            }
        }

        protected void btnDeleteClass_Click(object sender, EventArgs e)
        {
            string className = lstClasses.SelectedItem.Text;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string deleteQuery = "delete from [Classes] where Name=@className";
            SqlCommand comm = new SqlCommand(deleteQuery, conn);
            comm.Parameters.AddWithValue("@className", className);
            comm.ExecuteNonQuery();
            conn.Close();
            updateClassList();
        }

        protected void btnAddFormToClass_Click(object sender, EventArgs e)
        {
            string className = lstClasses.SelectedItem.Text;
            string formName = drpFormsList.SelectedItem.Text;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string insertQuery = "insert into [ClassFormConnection] ([ClassName],[FormName]) values (@ClassName,@FormName)";
            SqlCommand comm = new SqlCommand(insertQuery, conn);
            comm.Parameters.AddWithValue("@ClassName", className);
            comm.Parameters.AddWithValue("@FormName", formName);
            comm.ExecuteNonQuery();
            conn.Close();
            updateClassForms();
        }
    }
}