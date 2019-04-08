using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.Data
{
    public class Explanations
    {
        public int ID { get; set; }
        public string Explanation  { get; set; }
        public int VocabularyID { get; set; }
        [ForeignKey("VocabularyID")]
        public virtual Vocabulary Vocabulary { get; set; }
    }
}
