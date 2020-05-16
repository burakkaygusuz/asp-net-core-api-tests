using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.Models.Data;

namespace MovieDatabase.API.Models.Extensions
{
    public class MovieDatabaseContext : DbContext
    {
        public MovieDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to many relationship between Movie and Director

            modelBuilder.Entity<MovieDirector>().HasKey(md => new { md.MovieId, md.DirectorId });

            modelBuilder.Entity<MovieDirector>().HasOne(m => m.Movie).WithMany(md => md.MovieDirectors)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<MovieDirector>().HasOne(d => d.Director).WithMany(d => d.MovieDirectors)
                .HasForeignKey(d => d.DirectorId);

            //Many to many relationship between Movie and Genre

            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieGenre>().HasOne(m => m.Movie).WithMany(mg => mg.MovieGenres)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<MovieGenre>().HasOne(g => g.Genre).WithMany(mg => mg.MovieGenres)
                .HasForeignKey(g => g.GenreId);

            base.OnModelCreating(modelBuilder);
        }
    }
}