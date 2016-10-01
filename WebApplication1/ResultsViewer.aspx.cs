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

                // The following string gets the relevant data for one entry with each time a student has been evaluated by a peer
                getDataString = "select * from(" +
                                    " select t1.FullName as evaluator, FormsAnswers.Grade as grade" +
                                    " from FormsAnswers" +
                                    " inner join Account t1 on t1.[ASU ID] = FormsAnswers.[ASU ID]" +
                                    " inner join Account t2 on t2.[ASU ID] = FormsAnswers.[PeerID]" +
                                    " where PeerID = @peerID" +
                                    " and ClassName = @className" +
                                    " and FormName = @formName) as t" +
                                    " group by evaluator,grade";
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
                            result.PeersNameGrade[reader.GetString(0)] = float.Parse(reader.GetString(1));
                        }
                        reader.Close();
                    }
                }

                // Start writing table header
                string tableCode = "<table width='800' border='1'><tr><th>Student</th><th>Status</th><th>Reviewed by</th><th>Reviewer Grade</th><th>Grade Release</th></tr>";
                panelFormResults.Controls.Add(new LiteralControl(tableCode));

                // Add table data
                int rowspan;
                foreach (FormResult result in formResults) {
                    rowspan = result.PeersNameGrade.Count;
                    List<string> evaluators = new List<string>(result.PeersNameGrade.Keys);

                    tableCode = "<tr>" + getCellHtml(result.FullName, rowspan) + getCellHtml("<i>NotImplemented</i>", rowspan) + getCellHtml(evaluators[0], 1) + getCellHtml(result.PeersNameGrade[evaluators[0]].ToString("F2"), 1) + getCellHtml(result.getFormattedGrade(), rowspan) + "</tr>";
                    for (int i = 1; i < evaluators.Count; i++) {
                        tableCode += "<tr>" + getCellHtml(evaluators[i], 1) + getCellHtml(result.PeersNameGrade[evaluators[i]].ToString("F2"), 1) + "</tr>";
                    }
                    panelFormResults.Controls.Add(new LiteralControl(tableCode));
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
    }
}