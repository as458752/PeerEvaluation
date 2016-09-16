using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PeerEvaluation
{
    [Serializable]
    public class Question
    {
        private int type; // 0: multiple choice   1: short answer
        private string description;
        private string[] choice;

        private List<Control> answerFields;

        public List<Control> AnswerFields
        {
            get { return answerFields; }
            set { answerFields = value; }
        }

        public Question(int t,string des)
        {
            type = t;
            description = des;
            if(t==0) choice = new string[5];
            answerFields = new List<Control>();
        }
        public void setChoice(int i,string cho)
        {
            choice[i] = cho;
        }
        public string getChoice(int i)
        {
            if (choice != null)
                return choice[i];
            else
                return "";
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

        public string getAnswer()
        {
            if(type == 0)
            {
                // Multiple choice, look for the selected radio button
                foreach(Control c in answerFields)
                {
                    RadioButton rb = (RadioButton)c;
                    if (rb.Checked) return rb.Text;
                }
                return "";
            }
            else
            {
                // Short answer, get Text from TextBox
                TextBox tb = (TextBox)answerFields[0];
                return tb.Text;
            }
        }
    }
}