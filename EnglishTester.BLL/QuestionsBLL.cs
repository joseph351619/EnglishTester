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
        QuestionsDAL questionsDAL = new QuestionsDAL();
        public void InsertQuestion(Questions question, List<Answers> answers)
        {
            int questionNo = 0;
            using (QuestionsDAL dal = new QuestionsDAL())
            {
                question.VocabularyID = vocabulary.ID;
                dal.Add(question);
                dal.Save();
                questionNo = question.NO;
            }
            using (OptionsDAL dal = new OptionsDAL())
            {
                dal.Add(options);
                dal.Save();
            }

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
        public IEnumerable<Questions> ReadAll()
        {
            using (QuestionsDAL dal = new QuestionsDAL())
            {
                return dal.ReadAll();
            }
        }
        public void Delete(Questions question)
        {
             questionsDAL.Delete(question);
        }
    }
}
