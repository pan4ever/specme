using Microsoft.EntityFrameworkCore;
using Specme.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Specme.Server.DB
{
    public class SpecmeContext: DbContext
    {
        public SpecmeContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var projectBuilder = modelBuilder.Entity<Project>();
            projectBuilder.HasKey(p => p.UUID);
            projectBuilder.HasIndex(p => p.Title).IsUnique();

            projectBuilder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(200);
            projectBuilder.Property(p => p.Description)
                .HasMaxLength(2000);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Project> Projects { get; set; }
    }
}
