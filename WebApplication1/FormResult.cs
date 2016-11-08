using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeerEvaluation {
    public class FormResult {
        public string AsuID { get; }
        public string FullName { get; }
        public string Date { get; set; }
        public string Time { get; set; }
        private Dictionary<string, string> idToName;
        private Dictionary<string, float> idToGrade;
        private Dictionary<string, string> idToDate;
        private Dictionary<string, string> idToTime;
        public int NumberOfPeers { get; set; }

        public FormResult(string asuID, string fullName) {
            AsuID = asuID;
            FullName = fullName;
            idToName = new Dictionary<string, string>();
            idToGrade = new Dictionary<string, float>();
            idToDate = new Dictionary<string, string>();
            idToTime = new Dictionary<string, string>();
        }

        public string getFormattedGrade() {
            float gradeAcc = 0.0f;
            foreach (string peerName in idToGrade.Keys) {
                gradeAcc += idToGrade[peerName];
            }
            return (gradeAcc / idToGrade.Keys.Count).ToString("F2");
        }

        public string getStatusString() {
            if (NumberOfPeers == idToGrade.Count)
                return "Graded";
            return "Ungraded";            
        }

        // The following methods act as interfaces for the dictionaries
        public void addEvaluatorData(string evaluatorID, string evaluatorName, float evaluatorGrade, string date, string time) {
            idToName[evaluatorID] = evaluatorName;
            idToGrade[evaluatorID] = evaluatorGrade;
            idToDate[evaluatorID] = date;
            idToTime[evaluatorID] = time;
        }

        public int getNumberOfEvaluators() {
            return idToName.Count;
        }

        public List<string> getEvaluatorIDs() {
            return new List<string>(idToName.Keys);
        }

        public string getEvaluatorName(string evaluatorID) {
            return idToName[evaluatorID];
        }

        public float getEvaluatorGrade(string evaluatorID) {
            return idToGrade[evaluatorID];
        }

        public string getEvaluationDate(string evaluatorID) {
            return idToDate[evaluatorID];
        }

        public string getEvaluationTime(string evaluatorID) {
            return idToTime[evaluatorID];
        }
    }
}