using Cookbook.DbInfrastructure;
using Cookbook.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Repositories
{
    public class TagRepository : BaseCookbookRepository<Tag>
    {
        public TagRepository( CookbookDbContext db )
            : base( db )
        {

        }
    }
}
