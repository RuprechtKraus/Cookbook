using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Cookbook.DAL;
using Cookbook.DTOs;
using Cookbook.DTOs.Converters;
using Cookbook.Settings;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Cookbook.Helpers;
using System.IO;
using Cookbook.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Cookbook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;

        public RecipeController(IConfiguration configuration, IOptions<AppSettings> appSettings)
        {
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
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

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetPreviews()
        {
            var recipes = _unitOfWork.RecipeRepository.Get(includeProperties: "Tags,User");
            return Ok(recipes.Select(r => r.ToPreviewDTO()).ToList());
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateRecipe([FromBody] RecipeCreateDTO recipeDTO)
        {
            string imageAssetsPath = _appSettings.ImageAssetsPath;
            string imageExtension = _appSettings.ImageFormat;
            string imageAssetsPathFrontend = _appSettings.ImageAssetsPathForFrontend;

            try
            {
                string imageName = ImageHelper
                    .SaveImageFromBase64(recipeDTO.ImageBase64, imageAssetsPath, imageExtension);
                string imagePathFrontend = Path.Combine(imageAssetsPathFrontend, imageName);

                Recipe recipe = new Recipe
                {
                    Name = recipeDTO.Name,
                    Description = recipeDTO.Description,
                    CookingTimeInMinutes = recipeDTO.CookingTimeInMinutes,
                    ServingsAmount = recipeDTO.ServingsAmount,
                    UserID = recipeDTO.UserID,
                    RecipeSteps = recipeDTO.RecipeSteps
                        .Select(s => ConvertStepDTO(s))
                        .ToList(),
                    IngredientsSections = recipeDTO.IngredientsSections
                        .Select(s => ConvertIngredientsSectionDTO(s))
                        .ToList(),
                    Tags = recipeDTO.Tags.Select(t => new Tag{ Name = t }).ToList(),
                    ImageURL = imagePathFrontend
                };

                _unitOfWork.RecipeRepository.Insert(recipe);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.RecipeRepository.Delete(id);
                _unitOfWork.Save();
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        private RecipeStep ConvertStepDTO(RecipeStepDTO dto)
        {
            return new RecipeStep
            {
                StepIndex = dto.StepIndex,
                Description = dto.Description
            };
        }

        private IngredientsSection ConvertIngredientsSectionDTO(IngredientsSectionDTO dto)
        {
            return new IngredientsSection
            {
                Name = dto.Name,
                Products = dto.Products
            };
        }
    }
}
