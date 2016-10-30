using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation {
    public partial class EvaluationResult : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string evaluatorID = Request.Params["evrID"];
                string evaluatedID = Request.Params["evtID"];
                string className = Session["ClassName"].ToString();
                string formName = Session["FormName"].ToString();

                lblClassName.Text = className;
                lblFormName.Text = formName;
                lblEvaluated.Text = getStudentName(evaluatedID);
                lblEvaluator.Text = getStudentName(evaluatorID);

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();

                string sqlString = "SELECT Description, Answer FROM FormsAnswers WHERE" +
                    " ClassName=@className AND FormName=@formName" +
                    " AND [ASU ID] = @evaluatorID AND PeerID = @evaluatedID";
                SqlCommand command = new SqlCommand(sqlString, conn);
                command.Parameters.AddWithValue("@className", className);
                command.Parameters.AddWithValue("@formName", formName);
                command.Parameters.AddWithValue("@evaluatorID", evaluatorID);
                command.Parameters.AddWithValue("@evaluatedID", evaluatedID);

                SqlDataReader reader = command.ExecuteReader();

                int questionNumber = 1;
                if (reader.HasRows) {
                    string question;
                    string answer;
                    while (reader.Read()) {
                        question = "<b>" + questionNumber + ") " + reader.GetString(0) + "</b></br>";
                        panelFormResults.Controls.Add(new LiteralControl(question));

                        answer = reader.GetString(1) + "<br/><br/>";
                        panelFormResults.Controls.Add(new LiteralControl(answer));

                        questionNumber++;
                    }
                }
                reader.Close();
                conn.Close();
            }
            
        }

        protected void btnReturn_Click(object sender, EventArgs e) {
            Response.Redirect("ResultsViewer.aspx");
        }

        protected string getStudentName(string asuID) {
            string name = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();

            string sqlString = "SELECT FullName From Account WHERE [ASU ID] = @asuID";
            SqlCommand command = new SqlCommand(sqlString, conn);
            command.Parameters.AddWithValue("@asuID", asuID);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                reader.Read();
                name = reader.GetString(0);
            }
            reader.Close();
            conn.Close();
            return name;
        }
    }
}