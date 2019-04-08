using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.Data
{
    public class Answers
    {
        public Answers(int index, string content, bool isAnswer)
        {
            Index = index;
            Content = content;
            IsAnswer = isAnswer;
        }
        public int Index { get; set; }
        public string Content { get; set; }
        public bool IsAnswer { get; set; }
    }
}
