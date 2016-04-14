using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeerEvaluation
{
    [Serializable]
    public class Question
    {
        private int type; // 0: multiple choice   1: short answer
        private string description;
        private string[] choice;
        public Question(int t,string des)
        {
            type = t;
            description = des;
            if(t==0) choice = new string[5];
        }
        public void setChoice(int i,string cho)
        {
            choice[i] = cho;
        }
        public string getChoice(int i)
        {
            return choice[i];
        }
        public string getDescription()
        {
            return description;
        }
        public void setDescription(string des)
        {
            description = des;
        }
        public int getType()
        {
            return type;
        }
    }
}