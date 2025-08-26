using FilmLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Database
{
    public class FilmsDBContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<FilmsActors> FilmActors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=filmLibrary.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmsActors>()
                .HasKey(fa => new { fa.FilmId, fa.ActorId });

            modelBuilder.Entity<FilmsActors>()
                .HasOne(fa => fa.Film)
                .WithMany(f => f.FilmActors)
                .HasForeignKey(fa => fa.FilmId);

            modelBuilder.Entity<FilmsActors>()
                .HasOne(fa => fa.Actor)
                .WithMany(a => a.FilmActors)
                .HasForeignKey(fa => fa.ActorId);
        }
    }
}
