using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Abstraction;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        
        public Repository(MapDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }
 
        public IQueryable<TEntity> FindAll()
        {
            return _dbSet;
        }
 
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
 
        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
 
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
 
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}