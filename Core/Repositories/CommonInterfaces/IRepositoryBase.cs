using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.CommonInterfaces
{
    public interface IRepositoryBase<T> where T : class, IEntityBase, new()
    {
        public T Add(T entity);
        public bool Any(Expression<Func<T, bool>> filter);
        public T Get(Expression<Func<T, bool>> filter);
        public List<T> GetList(Expression<Func<T, bool>>? filter = null);
        public bool Remove(T entity);
        public T Update(T entity);
        
    }
}
