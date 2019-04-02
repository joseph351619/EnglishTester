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
    public class Questions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NO { get; set; }
        public string Question { get; set; }
        public string Explanation { get; set; }
        public AnswerType Type { get; set; }

    }
}
