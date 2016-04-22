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
    public partial class FormCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblType.SelectedIndex == 0) setToVisible(true);
            else setToVisible(false);
        }

        private void setToVisible(bool visible)
        {
            if (visible)
            {
                lblChoices.Visible = true;
                lblChoice1.Visible = true;
                lblChoice2.Visible = true;
                lblChoice3.Visible = true;
                lblChoice4.Visible = true;
                lblChoice5.Visible = true;
                txtChoice1.Visible = true;
                txtChoice2.Visible = true;
                txtChoice3.Visible = true;
                txtChoice4.Visible = true;
                txtChoice5.Visible = true;
            }
            else
            {
                lblChoices.Visible = false;
                lblChoice1.Visible = false;
                lblChoice2.Visible = false;
                lblChoice3.Visible = false;
                lblChoice4.Visible = false;
                lblChoice5.Visible = false;
                txtChoice1.Visible = false;
                txtChoice2.Visible = false;
                txtChoice3.Visible = false;
                txtChoice4.Visible = false;
                txtChoice5.Visible = false;
            }
        }

        private void refreshList()
        {
            ListBox1.Items.Clear();
            EvaluationForm eForm = Session["eForm"] as EvaluationForm;
            foreach (Question q in eForm.getQuestions())
            {
                ListBox1.Items.Add(q.getDescription());
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Question q = new Question(rblType.SelectedIndex, txtDescription.Text);
            q.setDescription(txtDescription.Text);
            if (rblType.SelectedIndex == 0)
            {
                q.setChoice(0, txtChoice1.Text);
                q.setChoice(1, txtChoice2.Text);
                q.setChoice(2, txtChoice3.Text);
                q.setChoice(3, txtChoice4.Text);
                q.setChoice(4, txtChoice5.Text);
            }
            EvaluationForm eForm;
            if (Session["eForm"] != null) eForm = Session["eForm"] as EvaluationForm;
            else eForm = new EvaluationForm();
            eForm.addQuestion(q);
            Session["eForm"] = eForm;
            txtDescription.Text = "";
            txtChoice1.Text = "";
            txtChoice2.Text = "";
            txtChoice3.Text = "";
            txtChoice4.Text = "";
            txtChoice5.Text = "";
            refreshList();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaluationForm eForm = Session["eForm"] as EvaluationForm;
            Question q = eForm.getQuestions(ListBox1.SelectedIndex);
            txtDescription.Text = q.getDescription();
            if (q.getType() == 0)
            {
                rblType.SelectedIndex = 0;
                setToVisible(true);
                txtChoice1.Text = q.getChoice(0);
                txtChoice2.Text = q.getChoice(1);
                txtChoice3.Text = q.getChoice(2);
                txtChoice4.Text = q.getChoice(3);
                txtChoice5.Text = q.getChoice(4);
            }
            else
            {
                rblType.SelectedIndex = 1;
                setToVisible(false);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            EvaluationForm eForm = Session["eForm"] as EvaluationForm;
            Question q = eForm.getQuestions(ListBox1.SelectedIndex);
            q.setDescription(txtDescription.Text);
            if (rblType.SelectedIndex == 0)
            {
                q.setChoice(0, txtChoice1.Text);
                q.setChoice(1, txtChoice2.Text);
                q.setChoice(2, txtChoice3.Text);
                q.setChoice(3, txtChoice4.Text);
                q.setChoice(4, txtChoice5.Text);
            }
            eForm.replaceQuestion(ListBox1.SelectedIndex, q);
            Session["eForm"] = eForm;
            refreshList();
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            EvaluationForm eForm = Session["eForm"] as EvaluationForm;
            eForm.setName(txtName.Text);
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\"+txtName.Text+".txt");
            //serialize
            using (Stream stream = File.Open(fLocation, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, eForm);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFiles)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                StreamReader sr = new StreamReader(fileUpload.FileContent);
                do
                {
                    string line = sr.ReadLine();
                    string[] value = line.Split(',');
                    string checkPasswordQuery = "insert into [Forms] values ('" + value[0] + "','" + value[1] + "','" + value[2] + "')";
                    SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
                    passComm.ExecuteScalar();
                } while (sr.Peek() != -1);
                sr.Close();
                conn.Close();
            }
        }
    }
}