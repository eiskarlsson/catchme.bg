﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg.Models
{
    public class catchmebgContext : IdentityDbContext<CatchmebgUser>
    {
        public catchmebgContext(DbContextOptions<catchmebgContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CatchmebgUser>(entity =>
            {
                entity.Property(p => p.UserPhoto).HasMaxLength(1000000);
                entity.Property(p => p.Mbti).HasMaxLength(10);
            });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<CatchmebgUser>().ToTable("CatchmebgUser");
        }
    }
}
