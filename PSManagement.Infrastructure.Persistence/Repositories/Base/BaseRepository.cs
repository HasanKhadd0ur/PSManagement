using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T> where T :BaseEntity
    {
        protected AppDbContext _dbContext;
        internal DbSet<T> dbSet;
        public BaseRepository(AppDbContext context)
        {
            _dbContext = context;

            dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T>  entry   = await dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;

        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> specification)
        {
            var q = ApplySpecification(specification);

            return await q.ToListAsync<T>();
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id, ISpecification<T> specification=null)
        {
            var q = ApplySpecification(specification);
            return await q.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async  Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        protected IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(dbSet.AsQueryable(), specification);
        }

    }

}
