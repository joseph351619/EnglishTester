﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.Data
{
    public class QuestionSource
    {
        public QuestionSource() { }
        public QuestionSource(string source, int? sourceTypeID = null)
        {
            Source = source;
            SourceTypeID = sourceTypeID;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Source { get; set; }
        public int? SourceTypeID { get; set; }
        [ForeignKey("SourceTypeID")]
        public SourceType Type { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
    }
}
