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
        private Dictionary<string, string> evaluatorsIDToName;
        private Dictionary<string, float> evaluatorsIDToGrade;        
        public int NumberOfPeers { get; set; }

        public FormResult(string asuID, string fullName) {
            AsuID = asuID;
            FullName = fullName;
            evaluatorsIDToName = new Dictionary<string, string>();
            evaluatorsIDToGrade = new Dictionary<string, float>();            
        }

        public string getFormattedGrade() {
            float gradeAcc = 0.0f;
            foreach (string peerName in evaluatorsIDToGrade.Keys) {
                gradeAcc += evaluatorsIDToGrade[peerName];
            }
            return (gradeAcc / evaluatorsIDToGrade.Keys.Count).ToString("F2");
        }

        public string getStatusString() {
            if (NumberOfPeers == evaluatorsIDToGrade.Count)
                return "Graded";
            return "Ungraded";            
        }

        // The following methods act as interfaces for the dictionaries containing
        // names and grades
        public void addEvaluatorData(string evaluatorID, string evaluatorName, float evaluatorGrade) {
            evaluatorsIDToName[evaluatorID] = evaluatorName;
            evaluatorsIDToGrade[evaluatorID] = evaluatorGrade;
        }

        public int getNumberOfEvaluators() {
            return evaluatorsIDToName.Count;
        }

        public List<string> getEvaluatorIDs() {
            return new List<string>(evaluatorsIDToName.Keys);
        }

        public string getEvaluatorName(string evaluatorID) {
            return evaluatorsIDToName[evaluatorID];
        }

        public float getEvaluatorGrade(string evaluatorID) {
            return evaluatorsIDToGrade[evaluatorID];
        }
    }
}