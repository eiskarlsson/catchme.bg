using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class Evaluation
    {
        public List<Question> Questions { set; get; }
        public Evaluation()
        {
            Questions = new List<Question>();
        }
    }
}
