using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cookbook.DAL;
using Cookbook.DTOs.Converters;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        [HttpGet("{id}")]
        public IActionResult GetRecipeInfo(int id)
        {
            var recipe = _unitOfWork.RecipeRepository
                .Get(r => r.RecipeID == id, null, "RecipeSteps,IngredientsSections,Tags,User")
                .SingleOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe.ToDTO());
        }
    }
}
