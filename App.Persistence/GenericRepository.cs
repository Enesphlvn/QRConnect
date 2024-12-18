﻿using App.Application.Contracts.Persistence;
using App.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Persistence
{
    public class GenericRepository<T, TId>(AppDbContext context) : IGenericRepository<T, TId> where T : BaseEntity<TId> where TId : struct
    {
        protected AppDbContext Context = context;
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async ValueTask AddAsync(T entity)
        {
            if (entity is IAuditEntity auditEntity)
            {
                auditEntity.Created = DateTimeOffset.UtcNow;
            }

            entity.IsStatus = true;

            await _dbSet.AddAsync(entity);
        }

        public Task<bool> AnyAsync(TId id)
        {
            return _dbSet.AnyAsync(x => x.Id.Equals(id));
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public ValueTask<T?> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            if (entity is IAuditEntity auditEntity)
            {
                auditEntity.Updated = DateTimeOffset.UtcNow;
            }

            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking();
        }

        public async Task<bool> PassiveAsync(TId id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity is null) return false;

            entity.IsStatus = false;

            if (entity is IAuditEntity auditEntity)
            {
                auditEntity.Updated = DateTimeOffset.Now;
            }

            _dbSet.Update(entity);
            await Context.SaveChangesAsync();

            return true;
        }
    }
}
