using MovieDatabase.API.Models.Data;
using MovieDatabase.API.Models.Extensions;
using MovieDatabase.API.Services.Interfaces;

namespace MovieDatabase.API.Services.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}