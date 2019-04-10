using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.DAL
{
    public class QuestionSourceDAL : DALBase<QuestionSource>
    {
        public IEnumerable<QuestionSource> SearchQuestion(string words)
        {
            Reads();
            Data = Data.Where(a => a.Source.Contains(words));
            return Data;
        }
    }
}
