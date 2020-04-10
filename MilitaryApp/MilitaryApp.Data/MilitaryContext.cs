using Microsoft.EntityFrameworkCore;
using MilitaryApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryApp.Data
{
    public class MilitaryContext : DbContext
    {
        public DbSet<Military> Militaries { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<King> Kings { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Horse> Horses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local)\\SQLexpress;Initial Catalog=MilitaryDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // For many to many relationship
            modelBuilder.Entity<MilitaryBattle>().HasKey(m => new { m.MilitaryId, m.BattleId });

            // Other options to create table is via modelbuilder
            // modelBuilder.Entity<Horse>().ToTable("Horses");

        }
    }
}
