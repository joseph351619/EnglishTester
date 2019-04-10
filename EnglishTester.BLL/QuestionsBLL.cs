using EnglishTester.DAL;
using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.BLL
{
    public class QuestionsBLL : BLLBase<Questions>
    {
        QuestionsDAL questionsDAL = new QuestionsDAL();
        public QuestionsBLL()
        {
            IDAL = questionsDAL;
        }
        public bool InsertQuestion(Questions question, List<Options> options)
        {
            if(options == null || options.Count() == 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(question.Question))
            {
                return false;
            }
            if (!question.Question.Contains("_"))
            {
                return false;
            }
            if (options.Any(a => string.IsNullOrEmpty(a.Content)))
            {
                return false;
            }
            using (QuestionsDAL dal = new QuestionsDAL())
            {
                question.InsertTime = DateTime.Now;
                dal.Add(question);
                dal.Save();
            }
            using (OptionsDAL dal = new OptionsDAL())
            {
                options.ForEach(a => a.QuestionNo = question.NO);
                dal.Add(options);
                dal.Save();
            }
            return true;
        }
        public Questions GetQuestions(int questionNo)
        {
            using (QuestionsDAL dal = new QuestionsDAL())
            {
                return dal.Read(a => a.NO == questionNo, a=> a.Vocabulary);
            }
        }
        public List<int> GetAllQuestionsNo()
        {
            using (QuestionsDAL dal = new QuestionsDAL())
            {
                dal.Reads();
                return dal.Data.Select(a => a.NO).ToList();
            }
        }
        //public IEnumerable<Questions> ReadAll()
        //{
        //    using (QuestionsDAL dal = new QuestionsDAL())
        //    {
        //        return dal.ReadAll();
        //    }
        //}
        //public void Delete(Questions question)
        //{
        //     questionsDAL.Delete(question);
        //}
    }
}
