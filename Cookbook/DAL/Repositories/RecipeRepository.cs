using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Cookbook.Models;
using Cookbook.DAL.DbInfrastructure;
using Cookbook.DTOs;
using Microsoft.EntityFrameworkCore.Query;
using Cookbook.DTOs.Converters;

namespace Cookbook.DAL.Repositories
{
    public class RecipeRepository : Repository<Recipe>
    {
        public RecipeRepository(CookbookContext context)
            : base(context) 
        {  
        }
    }
}
