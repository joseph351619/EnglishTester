using EnglishTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.DAL
{
    public class VocabularyDAL:DALBase<Vocabulary>
    {
        //public void QuestionNoIs(int questionNo)
        //{
        //    Data = Data.Where(a => a.QuestionNo == questionNo);
        //}
        public void GetOrAdd(Vocabulary vocabulary)
        {
            Vocabulary existVocabulary = Read(a => a.Word == vocabulary.Word);
            if (existVocabulary == null)
            {
                Add(vocabulary);
                Save();
            }
            else
                vocabulary.ID = existVocabulary.ID;
        }
        //public bool IsExist(string word)
        //{
        //    return (Data.Where(a => a.Word == word).Count() > 0) ? true : false;
        //}
        //public override bool IsValidated(Vocabulary vocabulary)
        //{
        //    bool isValidated = false;
        //    isValidated = !IsExist(vocabulary.Word);
        //    return isValidated;
        //}
    }
}
