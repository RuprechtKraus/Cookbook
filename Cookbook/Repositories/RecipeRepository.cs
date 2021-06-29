using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Entities.Models;
using Cookbook.DbInfrastructure;
using Cookbook.Dtos;

namespace Cookbook.Repositories
{
    public class RecipeRepository : BaseCookbookRepository<Recipe>
    {
        public RecipeRepository( CookbookDbContext db )
            : base( db )
        {

        }
    }
}
