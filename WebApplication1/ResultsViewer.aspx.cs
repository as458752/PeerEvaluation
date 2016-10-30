using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation {
    public partial class ResultsViewer : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblWelcome.Text = "Welcome, " + Session["UserName"].ToString();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);

            // Check if there are any results for the specified class and form
            string getDataString = "select distinct [PeerID],[Account].[FullName] from [FormsAnswers] join [Account] on [Account].[ASU ID]=[FormsAnswers].[PeerID] where [FormsAnswers].[ClassName]=@className and [FormsAnswers].[FormName]=@formName";
            SqlCommand comm = new SqlCommand(getDataString, conn);
            comm.Parameters.AddWithValue("@className", Session["ClassName"].ToString());
            comm.Parameters.AddWithValue("@formName", Session["FormName"].ToString());
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows) {
                // Get all the PeerIDs and store in a List
                List<FormResult> formResults = new List<FormResult>();
                // Read 
                while (reader.Read()) {
                    formResults.Add(new FormResult(reader.GetString(0), reader.GetString(1)));
                }
                reader.Close();

                // Get the number of peers
                getDataString = "select count(*) from(" +
                                    " select[ASU ID] from Groups" +
                                    " where GroupNumber = (" +
                                    " select distinct GroupNumber from Groups" +
                                    " where[ASU ID] = @asuID)" +
                                    " and[ASU ID] != @asuID  and ClassName = @className) as t";
                comm = new SqlCommand(getDataString, conn);
                comm.Parameters.AddWithValue("@className", Session["ClassName"].ToString());
                comm.Parameters.Add("@asuID", SqlDbType.NChar);
                foreach(FormResult result in formResults) {
                    comm.Parameters["@asuID"].Value = result.AsuID;
                    result.NumberOfPeers = (int)comm.ExecuteScalar();                    
                }

                // The following string gets the relevant data for each time a student has been evaluated by a peer
                getDataString = "select * from(" +
                                    " select t1.[ASU ID] as evalID, t1.FullName as evalName, FormsAnswers.Grade as grade, FormsAnswers.Date as dateval,FormsAnswers.Time as timeval" +
                                    " from FormsAnswers" +
                                    " inner join Account t1 on t1.[ASU ID] = FormsAnswers.[ASU ID]" +
                                    " inner join Account t2 on t2.[ASU ID] = FormsAnswers.[PeerID]" +
                                    " where PeerID = @peerID" +
                                    " and ClassName = @className" +
                                    " and FormName = @formName) as t" +
                                    " group by evalID, evalName,grade,dateval,timeval";
                comm = new SqlCommand(getDataString, conn);
                comm.Parameters.Add("@peerID", SqlDbType.NChar);
                comm.Parameters.AddWithValue("@className", Session["ClassName"].ToString());
                comm.Parameters.AddWithValue("@formName", Session["FormName"].ToString());

                foreach (FormResult result in formResults) {
                    comm.Parameters["@peerID"].Value = result.AsuID;
                    reader = comm.ExecuteReader();
                    if (reader.HasRows) {
                        // The results contain an entry for every time the student has been evaluated
                        while (reader.Read()) {
                            // Add evaluator ID, name, grade
                            result.addEvaluatorData(reader.GetString(0), reader.GetString(1), float.Parse(reader.GetString(2)));
                            
                            result.Date = reader.GetString(3);
                            result.Time = reader.GetString(4);
                        }
                        reader.Close();
                    }
                }

                // Start writing table header
                string tableCode = "<table width='800' border='1'><tr>" +
                                    "<th>Student</th>" +
                                    "<th>Submitted</th>" + 
                                    "<th>Status</th>" + 
                                    "<th>Reviewed by</th>" + 
                                    "<th>Reviewer Grade</th>" + 
                                    "<th>Grade Release</th></tr>";
                panelFormResults.Controls.Add(new LiteralControl(tableCode));

                // Add table data
                int rowspan;
                foreach (FormResult result in formResults) {
                    rowspan = result.getNumberOfEvaluators();
                    List<string> evaluators = result.getEvaluatorIDs();

                    // Add initial data up to before the student evaluation links
                    tableCode = "<tr>" +
                        getCellHtml(result.FullName + "<br/>(" + result.AsuID.Trim() + ")", rowspan) +
                        getCellHtml(result.Date + "<br/>" + result.Time, rowspan) +
                        getCellHtml(result.getStatusString(), rowspan) + "<td rowspan='1'>";
                    panelFormResults.Controls.Add(new LiteralControl(tableCode));

                    // Add the link for the first evaluator
                    HyperLink evaluationResultsLink = new HyperLink();
                    evaluationResultsLink.Text = result.getEvaluatorName(evaluators[0]);
                    evaluationResultsLink.NavigateUrl = getEvaluationLink(evaluators[0], result.AsuID);
                    panelFormResults.Controls.Add(evaluationResultsLink);

                    // Add the rest of the row data                    
                    tableCode = "</td>" + getCellHtml(result.getEvaluatorGrade(evaluators[0]).ToString("F2"), 1) 
                        + getCellHtml(result.getFormattedGrade(), rowspan) 
                        + "</tr>";
                    panelFormResults.Controls.Add(new LiteralControl(tableCode));

                    // Add additional data for the rest of the evaluators
                    for (int i = 1; i < evaluators.Count; i++) {
                        tableCode = "<tr><td rowspan='1'>";
                        panelFormResults.Controls.Add(new LiteralControl(tableCode));

                        HyperLink newLink = new HyperLink();
                        newLink.Text = result.getEvaluatorName(evaluators[i]);
                        newLink.NavigateUrl = getEvaluationLink(evaluators[i], result.AsuID);
                        panelFormResults.Controls.Add(newLink);

                        tableCode = "</td>" + getCellHtml(result.getEvaluatorGrade(evaluators[i]).ToString("F2"), 1) + "</tr>";
                        panelFormResults.Controls.Add(new LiteralControl(tableCode));
                    }                    
                }                

                // Close table
                panelFormResults.Controls.Add(new LiteralControl("</table>"));
            } else {
                // No results were found in the database for the specified class and form
                lblResultsMessage.Text = "There are no results for this form.";
            }

            reader.Close();
            conn.Close();
        }

        protected void btnReturn_Click(object sender, EventArgs e) {
            Session["ClassName"] = null;
            Session["FormName"] = null;
            Response.Redirect("ClassManager.aspx");
        }

        protected string getCellHtml(string data, int rowspan) {
            return "<td rowspan='" + rowspan + "'>" + data + "</td>";
        }

        protected string getEvaluationLink(string evaluatorID, string evaluatedID) {
            return "EvaluationResult.aspx?evrID=" + evaluatorID + "&evtID=" + evaluatedID + "&";
        }
    }
}