using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class Question
    {
        public int ID { set; get; }
        public string QuestionText { set; get; }
        public string AnswerText1 { set; get; }
        public string AnswerText2 { set; get; }
        public Question()
        {
           
        }
    }
}
