using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public interface IProfileItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }
        int ItemId { get; set; }
        string Name { get; set; }
    }
}
