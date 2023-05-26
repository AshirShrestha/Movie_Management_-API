using Microsoft.EntityFrameworkCore;
using MovieManagementAPI.Models;

namespace MovieManagementAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Movie>Movie { get; set; }
        public DbSet<MovieDetails> MovieDetails { get; set; }
        public DbSet<MovieMedia> MovieMedia { get; set; }
        public DbSet<MovieRating> MovieRating { get; set; }
        public DbSet<MovieReview> MovieReview { get; set; }
        public DbSet<UserFavourite> UserFavourite { get; set; }
        public DbSet<UserMovieLog> UserMovieLog { get; set; }
       
    }
}
