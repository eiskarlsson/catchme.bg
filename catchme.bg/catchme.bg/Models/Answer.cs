using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class Answer
    {
        public int ID { set; get; }
        public int QuestionID { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Must select an answer!")]
        public int? SelectedAnswer { set; get; }
    }
}
