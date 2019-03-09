using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class Filter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string FilterUserId { get; set; }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
