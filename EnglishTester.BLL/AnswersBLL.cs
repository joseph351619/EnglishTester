using EnglishTester.DAL;
using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.BLL
{
    public class AnswersBLL
    {
        public IEnumerable<Answers> GetAnswers(int questionNo)
        {
            using (AnswersDAL dal = new AnswersDAL())
            {
                dal.Reads();
                dal.QuestionNoIs(questionNo);
                return dal.Data.ToList();
            }
        }
    }
}
