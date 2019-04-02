using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EnglishTester.Common.Enums;

namespace EnglishTester.Data
{
    public class Answers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public string Explanation { get; set; }
        public int QuestionNo { get; set; }
        public AnswerType Type { get; set; }
    }
}
