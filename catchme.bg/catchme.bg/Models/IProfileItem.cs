using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public interface IProfileItem
    {
        int Id { get; set; }
        int ItemId { get; set; }
        string Name { get; set; }
    }
}
