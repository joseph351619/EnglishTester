using EnglishTester.DAL;
using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.BLL
{
    public class OptionsBLL : BLLBase<Options>
    {
        OptionsDAL dal = new OptionsDAL();
        public OptionsBLL()
        {
            IDAL = dal;
        }
        public IEnumerable<Options> GetOptions(int questionsNo)
        {
            return dal.GetOptions(questionsNo);
        }

    }
}
