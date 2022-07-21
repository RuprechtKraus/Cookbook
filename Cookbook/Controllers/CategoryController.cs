using Microsoft.AspNetCore.Mvc;
using Cookbook.DAL;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _unitOfWork.CategoryRepository.Get();
            return Ok(categories);
        }
    }
}