using Cookbook.Models;
using Cookbook.DAL.DbInfrastructure;

namespace Cookbook.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(CookbookContext context)
            : base(context)
        {
        }
    }
}
