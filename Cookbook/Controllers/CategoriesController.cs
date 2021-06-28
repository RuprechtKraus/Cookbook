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
    public class CategoriesController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public CategoriesController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET: api/Сategories
       [HttpGet]
        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = _unitOfWork.Categories
                .GetAll()
                .Select(item => item.ToDto())
                .ToList();
            return categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory( int id )
        {
            var category = _unitOfWork.Categories.Get( id ).ToDto();

            if ( category == null )
            {
                return NotFound();
            }

            return category;
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory( int id )
        {
            var category = _unitOfWork.Categories.Get( id );

            if (category == null )
            {
                return NotFound();
            }

            _unitOfWork.Categories.Remove( category );
            _unitOfWork.Save();

            return NoContent();
        }
    }
}
