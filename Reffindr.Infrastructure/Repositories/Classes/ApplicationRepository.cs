﻿using Microsoft.EntityFrameworkCore;
using Reffindr.Domain.Models;
using Reffindr.Infrastructure.Data;
using Reffindr.Infrastructure.Repositories.Interfaces;

namespace Reffindr.Infrastructure.Repositories.Classes
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {

        public ApplicationRepository(ApplicationDbContext options) : base(options)
        {
        }

        public async Task<List<Application>> GetApplicationsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(a => a.UserId == userId && !a.IsDeleted)
                .Include(a => a.Property)
                .ToListAsync();
        }
    }
}
