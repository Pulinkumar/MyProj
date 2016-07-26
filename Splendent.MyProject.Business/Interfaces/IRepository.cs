using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.Business.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Search Records
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter,
                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
                                  string includeProperties);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);


        //Add Records
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        //Update Records
        void Update(TEntity entity);

        //Remove Records
        void Remove(object id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
