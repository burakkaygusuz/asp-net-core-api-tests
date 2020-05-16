using Microsoft.EntityFrameworkCore;
using MovieDatabase.API.Models.Extensions;
using MovieDatabase.API.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.API.Services.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MovieDatabaseContext dbContext;

        public Repository(MovieDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }
    }
}