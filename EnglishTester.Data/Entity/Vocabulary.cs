using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.Data
{
    public class Vocabulary
    {
        public Vocabulary() { }
        public Vocabulary(string word)
        {
            Word = word;
        }
        private string word;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Word
        {
            get { return word; }
            set { word = value.Trim(); }
        }
        public int? OriginID { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Explanations> Explanations { get; set; }
    }
}
