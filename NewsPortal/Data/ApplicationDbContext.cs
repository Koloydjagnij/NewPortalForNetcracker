using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Models;

namespace NewsPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           Database.EnsureCreated();
        }
        public virtual DbSet<News> News { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Id);
                entity.ToTable("News");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Body).HasColumnName("Body");
                entity.Property(e => e.CreatedById).HasColumnName("CreatedById");
                entity.Property(e => e.CreatedDateTime).HasColumnName("CreatedDateTime");
                entity.Property(e => e.ChangedDateTime).HasColumnName("ChangedDateTime");

                entity.HasOne(d => d.CreatedByIdNavigation)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CreatedById)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UsersNews");
            });
        }
    }
}
