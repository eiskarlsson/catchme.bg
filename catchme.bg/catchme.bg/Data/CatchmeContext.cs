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

        public virtual  DbSet<Pets> Pets { get; set; }
        public virtual  DbSet<Children> Children { get; set; }
        public virtual  DbSet<Drugs> Drugs { get; set; }
        public virtual  DbSet<Diet> Diet { get; set; }
        public virtual  DbSet<Drinks> Drinks { get; set; }
        public virtual  DbSet<Smokes> Smokes { get; set; }
        public virtual  DbSet<Religion> Religion { get; set; }
        public virtual  DbSet<Ethnicity> Ethnicity { get; set; }
        public virtual  DbSet<Education> Education { get; set; }
        public virtual  DbSet<HairColor> HairColor { get; set; }
        public virtual  DbSet<EyeColor> EyeColor { get; set; }
        public virtual  DbSet<BodyType> BodyType { get; set; }
        public virtual  DbSet<Weight> Weight { get; set; }
        public virtual  DbSet<Height> Height { get; set; }
        public virtual  DbSet<Languages> Languages { get; set; }
        public virtual  DbSet<Gender> Gender { get; set; }
        public virtual  DbSet<Age> Age { get; set; }
        public virtual  DbSet<LookingFor> LookingFor { get; set; }
        public virtual  DbSet<MaritalStatus> MaritalStatus { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<PetsFilter> PetsFilter { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivateMessageDetail>(entity =>
            {
                entity.Property(e => e.PrivateMessageDetailId).HasColumnName("PrivateMessageDetailId");
                entity.Property(e => e.UserNameFrom).IsRequired().HasMaxLength(256).IsUnicode(true);
                entity.Property(e => e.UserNameTo).IsRequired().HasMaxLength(256).IsUnicode(true);
            });
            modelBuilder.Entity<Profile>()
                .Property(p => p.ID)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PetsFilter>()
                .Property(p => p.ID)
                .ValueGeneratedOnAdd();
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
