using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.DAL
{
    public class OptionsDAL :DALBase<Options>
    {

        public IEnumerable<Options> GetOptions(int questionNO)
        {
            Reads();
            return Data.Where(a => a.QuestionNo == questionNO);
        }
    }
}
