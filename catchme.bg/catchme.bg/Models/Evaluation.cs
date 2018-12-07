using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class Evaluation
    {
        public string UserName { get; set; }
        public List<Answer> Answers { set; get; }
        public Evaluation()
        {
            Answers = new List<Answer>();
        }
    }
}
