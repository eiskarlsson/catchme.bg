using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Models;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg.Data
{
    public class CatchmeContext : DbContext
    {
        public CatchmeContext(DbContextOptions<CatchmeContext> options) : base(options)
        {
        }

        public virtual DbSet<MessageDetail> MessageDetails { get; set; }
    }
}
