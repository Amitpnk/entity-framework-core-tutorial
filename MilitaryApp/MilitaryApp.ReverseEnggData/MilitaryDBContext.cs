using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MilitaryApp.ReverseEnggData
{
    public partial class MilitaryDBContext : DbContext
    {
        public MilitaryDBContext()
        {
        }

        public MilitaryDBContext(DbContextOptions<MilitaryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kings> Kings { get; set; }
        public virtual DbSet<Militaries> Militaries { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local)\\SQLexpress;Initial Catalog=MilitaryDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Militaries>(entity =>
            {
                entity.HasIndex(e => e.KingId);

                entity.HasOne(d => d.King)
                    .WithMany(p => p.Militaries)
                    .HasForeignKey(d => d.KingId);
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.HasIndex(e => e.MilitaryId);

                entity.HasOne(d => d.Military)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.MilitaryId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
