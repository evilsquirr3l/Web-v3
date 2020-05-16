using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Abstraction
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> FindAll();
        
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        
        Task Create(TEntity entity);
        
        void Update(TEntity entity);
        
        void Delete(TEntity entity);
    }
}