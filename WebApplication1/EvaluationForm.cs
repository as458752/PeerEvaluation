using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeerEvaluation
{
    [Serializable]
    public class EvaluationForm
    {
        private string professor;
        private string name;
        private List<Question> questions;
        public EvaluationForm()
        {
            questions = new List<Question>();
        }
        public EvaluationForm(string n,string p)
        {
            professor = p;
            name = n;
            questions = new List<Question>();
        }
        public Question getQuestions(int index)
        {
            return questions.ElementAt(index);
        }
        public List<Question> getQuestions()
        {
            return questions;
        }
        public void addQuestion(Question q)
        {
            questions.Add(q);
        }
        public void removeQuestion(int index)
        {
            questions.RemoveAt(index);
        }
        public void replaceQuestion(int index, Question q)
        {
            removeQuestion(index);
            questions.Insert(index, q);
        }
        public string getProfessor()
        {
            return professor;
        }
        public string getName()
        {
            return name;
        }
        public void setProfessor(string pro)
        {
            professor = pro;
        }
        public void setName(string n)
        {
            name = n;
        }

        public string getFormattedGrade() {
            float gradeAccum = 0;
            float counter = 0;
            foreach(Question q in questions) {
                if(q.getType() == 0) {
                    counter++;
                    gradeAccum += q.getGrade();
                }
            }
            gradeAccum /= counter;
            return gradeAccum.ToString("F1");
        }
    }
}