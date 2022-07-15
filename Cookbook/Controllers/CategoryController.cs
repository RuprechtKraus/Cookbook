using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Cookbook.DAL;
using Cookbook.Models;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<Category> Index()
        {
            var categories = _unitOfWork.CategoryRepository.Get();
            return categories;
        }
    }
}