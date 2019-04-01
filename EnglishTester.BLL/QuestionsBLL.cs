using EnglishTester.DAL;
using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.BLL
{
    public class QuestionsBLL
    {
        public void InsertQuestion(Questions question, List<Answers> answers)
        {
            int questionNo = 0;
            using (QusetionsDAL dal=new QusetionsDAL())
            {
                dal.Add(question);
                dal.Save();
                questionNo = question.NO;
            }
            using (AnswersDAL dal = new AnswersDAL())
            {
                answers.ForEach(i => i.QuestionNo = questionNo);
                dal.Add(answers);
                dal.Save();
            }

        }
    }
}
