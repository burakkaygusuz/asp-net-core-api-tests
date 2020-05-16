﻿using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.API.Services.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);
    }
}