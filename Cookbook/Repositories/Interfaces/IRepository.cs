using Cookbook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cookbook.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetWithEagerLoad(Expression<Func<T, bool>> filter, string children);
        public List<T> GetAll();
        public T Get( int id );
        public void Remove( T item );
    }
}
