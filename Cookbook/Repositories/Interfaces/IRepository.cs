using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Repositories
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T Get( int id );
        public void Remove( T item );
    }
}
