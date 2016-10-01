using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeerEvaluation {
    public class FormResult {
        public string AsuID { get; }
        public string FullName { get; }
        //public string Date { get; }
        //public string Time { get;}
        public Dictionary<string, float> PeersNameGrade { get; set; }

        public FormResult(string asuID, string fullName) {
            AsuID = asuID;
            FullName = fullName;
            PeersNameGrade = new Dictionary<string, float>();
        }

        public string getFormattedGrade() {
            float gradeAcc = 0.0f;
            foreach (string peerName in PeersNameGrade.Keys) {
                gradeAcc += PeersNameGrade[peerName];
            }
            return (gradeAcc / PeersNameGrade.Keys.Count).ToString("F2");
        }
    }
}