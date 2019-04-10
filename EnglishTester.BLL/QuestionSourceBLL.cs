using EnglishTester.DAL;
using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.BLL
{
    public class QuestionSourceBLL : BLLBase<QuestionSource>
    {
        QuestionSourceDAL dal = new QuestionSourceDAL();
        public QuestionSourceBLL()
        {
            IDAL = dal;
        }
        public IEnumerable<QuestionSource> SearchSource(string words)
        {
            return dal.SearchSource(words);
        }
    }
}
