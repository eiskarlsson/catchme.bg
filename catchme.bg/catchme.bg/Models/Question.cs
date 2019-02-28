using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    [DelimitedRecord(",")]
    public class Question : ExtensionMethods.IIdentifier
    {
        [FieldHidden]
        public int Id { set; get; }

        public int QuestionID { get; set; }
        public string QuestionText { set; get; }
        public string AnswerText1 { set; get; }
        public string AnswerText2 { set; get; }
        public string Language { get; set; }

        public Question()
        {
           
        }
    }
}
