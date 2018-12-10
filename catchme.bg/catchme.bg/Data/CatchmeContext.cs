using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace catchme.bg.Data
{
    public class CatchmeContext : DbContext
    {
        public CatchmeContext()
        {

        }

        public CatchmeContext(DbContextOptions<CatchmeContext> options) : base(options)
        {
        }

        public virtual DbSet<MessageDetail> MessageDetails { get; set; }

        public virtual DbSet<PrivateMessageDetail> PrivateMessageDetails { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Answer> Answers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivateMessageDetail>(entity =>
            {
                entity.Property(e => e.PrivateMessageDetailId).HasColumnName("PrivateMessageDetailId");
                entity.Property(e => e.UserNameFrom).IsRequired().HasMaxLength(256).IsUnicode(true);
                entity.Property(e => e.UserNameTo).IsRequired().HasMaxLength(256).IsUnicode(true);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("catchmebgContextConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
