using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Entities.Models;
using Cookbook.DbInfrastructure;

namespace Cookbook.Repositories
{
    public class UserRepository : BaseCookbookRepository<User>
    {
        public UserRepository(CookbookDbContext context)
            : base(context)
        {

        }
    }
}
