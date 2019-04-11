using EnglishTester.DAL;
using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.BLL
{
    public class VocabularyBLL : BLLBase<Vocabulary>
    {
        VocabularyDAL dal = new VocabularyDAL();
        public VocabularyBLL()
        {
            IDAL = dal;
        }
        public IEnumerable<Vocabulary> SearchVocabulary(string words)
        {
            return dal.SearchVocabulary(words);
        }
        //public IEnumerable<Vocabulary> GetAnswers(int questionNo)
        //{
        //    using (VocabularyDAL dal = new VocabularyDAL())
        //    {
        //        dal.Reads();
        //        dal.QuestionNoIs(questionNo);
        //        return dal.Data.ToList();
        //    }
        //}
        
    }
}
