using CinemaClub.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaClub.Web.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMoviesAsync();
    }
    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext _context;
        public MovieService(CinemaDbContext context) // зависимости приходят через конструктор
        {
            _context = context;
        }
        public async Task<List<Movie>> GetMoviesAsync()
        => await _context.Movies.ToListAsync(); // async — не блокируем поток

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
