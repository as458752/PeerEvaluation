using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
            if (Session["UserName"] == null) Response.Redirect("LoginPage.aspx");
            if (!IsPostBack)
            {
                //lblWelcome.Text = "Welcome, " + Session["UserName"].ToString();
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
            string className = txtClassName.Text;
            if (className != "") {
                // Check first if the class already exists
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string sqlString = "SELECT COUNT(Name) FROM Classes WHERE Name=@className";
                SqlCommand comm = new SqlCommand(sqlString, conn);
                comm.Parameters.AddWithValue("@className", className);
                int entries = (int)comm.ExecuteScalar();

                if(entries > 0) {
                    lblCreateClassMessage.Text = "The specified class already exists.";
                }else {
                    // Insert class data
                    sqlString = "insert into [Classes] ([Name],[CreatorID]) values (@Name,@CreatorID)";
                    comm = new SqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@Name", className);
                    comm.Parameters.AddWithValue("@CreatorID", Session["ASU ID"].ToString());
                    comm.ExecuteNonQuery();                    
                    txtClassName.Text = "";
                    updateClassList();
                    lblCreateClassMessage.Text = "";
                }
                conn.Close();
                
            } else {
                lblCreateClassMessage.Text = "Enter a name for the class.";
            }
        }

        private void updateClassList()
        {
            // Each time the class list is updated, an associated list of type Class is renewed
            List<Class> classList = new List<Class>();

            lstClasses.Items.Clear();
            // Select existing class data
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string getDataQuery = "select [Name],[CreatorID],[InfoAvailable] from[Classes] where[CreatorID] = '" + Session["ASU ID"].ToString() + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                string className;
                while (reader.Read())
                {
                    
                    className = reader.GetString(0);
                    Class newClass = new Class(className, reader.GetString(1), reader.GetSqlBoolean(2).IsTrue);
                    classList.Add(newClass);

                    string toAdd = className;
                    if (!newClass.InfoAvailable)
                    {
                        toAdd += " (information file not uploaded)";
                    }
                    lstClasses.Items.Add(toAdd);
                }
            }
            // Update the associated list of type Class
            Session["ClassList"] = classList;
        }

        protected void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDeleteClass.Enabled = true;
            btnUpload.Enabled = true;

            updateClassForms();
        }

        private void updateClassForms()
        {
            lstClassForms.Items.Clear();

            string className = ((List<Class>)Session["ClassList"])[lstClasses.SelectedIndex].Name;

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
            List<Class> classList = (List<Class>)Session["classList"];
            string className = classList[lstClasses.SelectedIndex].Name;

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
            if(lstClasses.SelectedItem != null) {
                List<Class> classList = (List<Class>)Session["classList"];
                if(drpFormsList.SelectedIndex > 0) {
                    // Check if the class hasn't already been assigned the form
                    string className = classList[lstClasses.SelectedIndex].Name;
                    string formName = drpFormsList.SelectedItem.Text;

                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                    conn.Open();
                    string sqlString = "SELECT COUNT(*) FROM ClassFormConnection WHERE ClassName=@className AND FormName=@formName";
                    SqlCommand comm = new SqlCommand(sqlString, conn);
                    comm.Parameters.AddWithValue("@ClassName", className);
                    comm.Parameters.AddWithValue("@FormName", formName);
                    int entries = (int)comm.ExecuteScalar();

                    if(entries == 0) {
                        sqlString = "insert into [ClassFormConnection] ([ClassName],[FormName]) values (@ClassName,@FormName)";
                        comm = new SqlCommand(sqlString, conn);
                        comm.Parameters.AddWithValue("@ClassName", className);
                        comm.Parameters.AddWithValue("@FormName", formName);
                        comm.ExecuteNonQuery();
                        updateClassForms();
                    } else {
                        lblFormsMessage.Text = "The selected class has already been assigned this form.";
                    }                   
                    conn.Close();                    
                }else {
                    lblFormsMessage.Text = "You must select a valid form.";
                }
                
            }else {
                lblFormsMessage.Text = "You must select a class first.";
            }
            
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fupStudentInfo.HasFiles)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                StreamReader sr = new StreamReader(fupStudentInfo.FileContent);

                string[] values;
                string sqlCommandString;
                SqlCommand sqlCommand;
                SqlDataReader reader;
                // For each line in the file
                while (sr.Peek() != -1)
                {
                    // Get ASU ID and check if it is already in the database
                    values = sr.ReadLine().Split(',');
                    string asuID = values[0];
                    string fullName = values[1];
                    string groupName = values[2];
                    

                    sqlCommandString = "select * from [Account] where [ASU ID] = '" + asuID + "'";
                    sqlCommand = new SqlCommand(sqlCommandString, conn);
                    reader = sqlCommand.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        reader.Close();                        
                        sqlCommandString = "insert into [Account] ([ASU ID],[FullName]) values ('" + asuID + "','" + fullName + "')";
                        sqlCommand = new SqlCommand(sqlCommandString, conn);
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Close();
                    }

                    // Once it has been guaranteed that the ASU ID is in the database,
                    // create a new entry in the Groups
                    string className = ((List<Class>)Session["ClassList"])[lstClasses.SelectedIndex].Name;

                    sqlCommandString = "insert into [Groups] ([ASU ID],[ClassName],[GroupNumber]) values (@asuID, @className, @groupName)";
                    sqlCommand = new SqlCommand(sqlCommandString, conn);
                    sqlCommand.Parameters.AddWithValue("@asuID", asuID);
                    sqlCommand.Parameters.AddWithValue("@className", className);
                    sqlCommand.Parameters.AddWithValue("@groupName", groupName);

                    sqlCommand.ExecuteNonQuery();

                    // Update the class to reflect the fact that the information file is now available                    
                    sqlCommandString = "update [Classes] set [InfoAvailable]='1' where [Name]='" + className + "'";
                    sqlCommand = new SqlCommand(sqlCommandString, conn);
                    sqlCommand.ExecuteNonQuery();
                }
                sr.Close();
                conn.Close();
                updateClassList();
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["ASU ID"] = null;
            Session["UserName"] = null;
            Session["ClassList"] = null;
            Response.Redirect("StudentLogin.aspx");
        }

        protected void btnRemoveForm_Click(object sender, EventArgs e) {
            if(lstClassForms.SelectedItem != null) {
                List<Class> classList = (List<Class>)Session["classList"];
                string className = classList[lstClasses.SelectedIndex].Name;
                string formName = lstClassForms.SelectedItem.Text;

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string deleteQuery = "delete from [ClassFormConnection] where [ClassName]=@className and [FormName]=@formName";
                SqlCommand comm = new SqlCommand(deleteQuery, conn);
                comm.Parameters.AddWithValue("@className", className);
                comm.Parameters.AddWithValue("@formName", formName);
                comm.ExecuteNonQuery();
                conn.Close();
                updateClassForms();
            } else {
                lblFormsMessage.Text = "You must select a form first.";
                lblFormsMessage.Visible = true;
            }
                       
        }

        protected void clickHere_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCreation.aspx");
        }

        protected void btnViewResults_Click1(object sender, EventArgs e)
        {
            if (lstClassForms.SelectedItem != null)
            {
                Session["FormName"] = lstClassForms.SelectedItem.Text;
                Session["ClassName"] = lstClasses.SelectedItem.Text;
                Response.Redirect("ResultsViewer.aspx");
            }
            else
            {
                lblFormsMessage.Text = "You must select a form first.";
                lblFormsMessage.Visible = true;
            }
        }
    }
}
