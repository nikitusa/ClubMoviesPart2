using CinemaClub.Web.Services;
using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;
namespace CinemaClub.Web.Models
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("chernovik");
            modelBuilder.Entity<Movie>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasOne(p => p.Director).WithMany(p=>p.Movies);
                e.HasMany(p => p.MovieActors).WithOne(p=>p.Movie);
            });
            modelBuilder.Entity<Director>(e =>
            {
                e.HasKey(p => p.Id);
                e.HasMany(p => p.Movies).WithOne(p => p.Director);
            });
            modelBuilder.Entity<Review>(e =>
            {
                e.HasKey(p => p.Id);
                
                e.HasOne(p => p.Member).WithMany(p => p.Reviews);
            });
            modelBuilder.Entity<Member>(e => e.HasKey(p => p.Id));
            modelBuilder.Entity<Actor>(e =>
            {
                e.HasKey(p => p.Id);
                
            });
            modelBuilder.Entity<MovieActor>(e => 
            {
                e.HasKey(p => new { p.Movie_id, p.Actor_id});
            });
        }

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) :base(options)
        {
            
        }
    }
}
