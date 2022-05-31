using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WAtest.Data;
using WAtest.Models;

namespace WAtest.Data
{
    public class WAtestContext: DbContext
    {
        public WAtestContext(DbContextOptions<WAtestContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");
            });

            builder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(d => new { d.GameId, d.GenreId });
                entity.ToTable("GameGenre");

                entity.HasOne(d => d.Game)
                .WithMany(d => d.GameGenres)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK_GameGenre_Game");

                entity.HasOne(d => d.Genre)
                .WithMany(d => d.GameGenres)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK_GameGenre_Genre");
            });

            builder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");
            });

            base.OnModelCreating(builder);
        }
    }
}
