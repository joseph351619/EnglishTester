using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTester.Common
{
    public class Enums
    {
        public enum AnswerType
        {
            Vocabulary,
            Gramarly,
            Article
        }
    }
    public class AnswerType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static List<AnswerType> Types()
        {
            return Enum.GetValues(typeof(Enums.AnswerType)).
                Cast<Enums.AnswerType>().
                Select(o => new AnswerType() {
                    ID = (int)o,
                    Name = o.ToString()
                }).ToList();
        }
        public static string ValueName()
        {
            return nameof(ID);
        }
        public static string DisplayName()
        {
            return nameof(Name);
        }
    }
}
