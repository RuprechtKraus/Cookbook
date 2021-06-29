using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cookbook.Entities;
using Cookbook.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Repositories
{
    abstract public class BaseCookbookRepository<EntityType>
        : IRepository<EntityType> where EntityType : Entity
    {
        public IEnumerable<EntityType> GetWithEagerLoad(Expression<Func<EntityType, bool>> filter, string children)
        {
            return Entities.Include(children).Where(filter).ToList();
        }

        private readonly DbInfrastructure.CookbookDbContext _context;
        protected DbSet<EntityType> Entities => _context.Set<EntityType>();

        public BaseCookbookRepository(DbInfrastructure.CookbookDbContext context)
        {
            _context = context;
        }

        public List<EntityType> GetAll() => Entities.ToList();

        public EntityType Get( int id ) => Entities.Find( id );

        public void Remove( EntityType entityToDelete )
        {
            Entities.Remove( entityToDelete );
        }
    }
}