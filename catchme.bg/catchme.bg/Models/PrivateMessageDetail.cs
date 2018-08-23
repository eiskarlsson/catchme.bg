using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catchme.bg.Models
{
    public class PrivateMessageDetail
    {
        public long PrivateMessageDetailId { get; set; }

        public string UserNameFrom { get; set; }

        public string UserNameTo { get; set; }

        public string Message { get; set; }
    }
}
