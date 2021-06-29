using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cookbook.DbInfrastructure;
using Cookbook.Entities.Models;
using Cookbook.Dtos;

namespace Cookbook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public RecipesController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: api/Recipes
        [HttpGet]
        public IEnumerable<RecipeToLoadDto> GetRecipes()
        {
            var recipes = _unitOfWork.Recipes.GetWithEagerLoad(r => r.Id > 0, "Tags");
            List<RecipeToLoadDto> recipesDtos = new List<RecipeToLoadDto>();

            foreach ( var r in recipes )
            {
                User owner = _unitOfWork.Users.Get( r.UserId );
                recipesDtos.Add( r.ToRecipeToLoadDto( owner ) );
            }

            return recipesDtos;
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public ActionResult<RecipeToLoadDto> GetRecipe(int id)
        {
            var recipes = _unitOfWork.Recipes.GetWithEagerLoad(r => r.Id == id, "Tags");

            if ( !recipes.Any() )
            {
                return NotFound();
            }

            var recipe = recipes.ElementAt( 0 );
            var owner = _unitOfWork.Users.Get( recipe.UserId );
            RecipeToLoadDto dto = recipe.ToRecipeToLoadDto( owner );

            return dto;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        //{
        //    if (id != recipe.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(recipe).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RecipeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Recipes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        //{
        //    _context.Recipes.Add(recipe);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
        //}

        //// DELETE: api/Recipes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRecipe(int id)
        //{
        //    var recipe = await _context.Recipes.FindAsync(id);
        //    if (recipe == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Recipes.Remove(recipe);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RecipeExists(int id)
        //{
        //    return _context.Recipes.Any(e => e.Id == id);
        //}
    }
}
