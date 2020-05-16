﻿using MovieDatabase.API.Models.Data;
using MovieDatabase.API.Models.Extensions;
using MovieDatabase.API.Services.Interfaces;

namespace MovieDatabase.API.Services.Repositories
{
    public class DirectorRepository : Repository<Director>, IDirectorRepository
    {
        public DirectorRepository(MovieDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}