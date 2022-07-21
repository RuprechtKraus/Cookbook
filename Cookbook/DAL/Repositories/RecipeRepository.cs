using Cookbook.Models;
using Cookbook.DAL.DbInfrastructure;
using System.IO;
using Cookbook.Settings;
using Microsoft.Extensions.Options;

namespace Cookbook.DAL.Repositories
{
    public class RecipeRepository : Repository<Recipe>
    {
        private readonly AppSettings _appSettings;

        public RecipeRepository(CookbookContext context, AppSettings appSettings)
            : base(context) 
        {  
            _appSettings = appSettings;
        }

        public override void Delete(int id)
        {
            string imageName = Path.GetFileName(_dbSet.Find(id).ImageURL);
            string imagePath = Path.Combine(_appSettings.ImageAssetsPath, imageName);
            base.Delete(id);
            File.Delete(imagePath);
        }
    }
}
