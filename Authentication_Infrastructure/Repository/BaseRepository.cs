﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Authentication_ApplicationCore.Contract.Repository;
using Authentication_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AuthenticationDbContext _dbContext;
        public BaseRepository(AuthenticationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().Where(filter).ToListAsync();
        }

        // For UserRole to include Navigations
        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.Where(where).ToListAsync();
        }

        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null) return false;
            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }

        public async Task<int> InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}
