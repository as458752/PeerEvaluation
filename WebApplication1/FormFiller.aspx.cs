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
    public partial class FormFiller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFormName.Text = (string)Session["FormName"];
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            // Get the group number in the given class
            string getDataQuery = "select [GroupNumber] from [Groups] where[ASU ID] = '" + Session["ASU ID"].ToString() + "' and [ClassName] = '" + Session["ClassName"].ToString() + "'";
            SqlCommand comm = new SqlCommand(getDataQuery, conn);
            SqlDataReader reader = comm.ExecuteReader();
            int groupNumber = 0;
            if (reader.HasRows)
            {                
                while (reader.Read())
                {
                    groupNumber = reader.GetInt32(0);
                }
            }
            reader.Close();
            // Get the peer names
            getDataQuery = "select [Username] from [Account] join [Groups] on [Account].[ASU ID]=[Groups].[ASU ID] where [Groups].[GroupNumber]=" + groupNumber + " and [Groups].[ASU ID] <> '" + Session["ASU ID"].ToString() + "'";
            comm = new SqlCommand(getDataQuery, conn);
            reader = comm.ExecuteReader();
            lblPeers.Text = "";
            string name;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.IsDBNull(0) ? "- (name not set yet)" : "- " + reader.GetString(0);
                    lblPeers.Text += name + "<br />";
                }
            }
            lblPeers.Text += "<br /><br />";
            reader.Close();
            

            // Fetch the form's questions
            getDataQuery = "select [Description],[Choice1],[Choice2],[Choice3],[Choice4],[Choice5] from [FormsQuestions] where [FormName]='" + Session["FormName"].ToString() + "'";
            comm = new SqlCommand(getDataQuery, conn);
            reader = comm.ExecuteReader();
            int questionNumber = 0;

            EvaluationForm evalForm = new EvaluationForm();
            // For each questions, create the controls dinamically
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    questionNumber += 1;
                    string description = reader.GetString(0);
                    string[] choices = new string[5];
                    for(int i = 1; i <= 5; i++)
                    {
                        choices[i-1] = reader.GetString(i);
                    }

                    // type 0: multiple answer, type 1: short answer
                    int type = choices[0] == "" ? 1 : 0;

                    Label qDescription = new Label();
                    qDescription.Text = questionNumber + ". " + description;
                    panelFormQuestions.Controls.Add(qDescription);
                    panelFormQuestions.Controls.Add(new LiteralControl("<br />"));

                    Question aQuestion;
                    if(type == 0)
                    {
                        aQuestion = new Question(0, description);
                        // Multiple answer
                        for(int i = 0; i < 5; i++)
                        {                            
                            RadioButton choice = new RadioButton();
                            choice.GroupName = questionNumber.ToString();
                            choice.Text = choices[i];
                            panelFormQuestions.Controls.Add(choice);
                            aQuestion.AnswerFields.Add(choice);
                            panelFormQuestions.Controls.Add(new LiteralControl("<br />"));
                        }
                        ((RadioButton)aQuestion.AnswerFields[0]).Checked = true;
                    }
                    else
                    {
                        aQuestion = new Question(1, description);
                        // Short answer
                        TextBox answerField = new TextBox();
                        answerField.TextMode = TextBoxMode.MultiLine;
                        answerField.Width = 500;
                        answerField.Rows = 3;
                        aQuestion.AnswerFields.Add(answerField);
                        panelFormQuestions.Controls.Add(answerField);
                    }
                    panelFormQuestions.Controls.Add(new LiteralControl("<br /><br />"));
                    evalForm.addQuestion(aQuestion);
                }                
            }
            reader.Close();
            conn.Close();
            Session["EvaluationForm"] = evalForm;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the evaluation form object containing the questions
            EvaluationForm evalForm = (EvaluationForm)Session["EvaluationForm"];

            // Prepare the connection to the database
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            foreach (Question q in evalForm.getQuestions())
            {
                // Insert each answer in the FormsAnswer table
                string insertDataStatement = "insert into [FormsAnswers] ([ASU ID],[ClassName],[FormName],[Description],[Answer]) values (@asuId,@className,@formName,@description,@answer)";
                SqlCommand comm = new SqlCommand(insertDataStatement, conn);
                comm.Parameters.AddWithValue("@asuId", Session["ASU ID"].ToString());
                comm.Parameters.AddWithValue("@className", Session["ClassName"].ToString());
                comm.Parameters.AddWithValue("@formName", Session["FormName"].ToString());
                comm.Parameters.AddWithValue("@description", q.getDescription());
                comm.Parameters.AddWithValue("@answer", q.getAnswer());
                comm.ExecuteNonQuery();
            }

            conn.Close();
            Response.Redirect("StudentPage.aspx");
        }
    }
}