using System.Collections.Generic;
using System.Linq;
using Cookbook.DAL;
using Cookbook.DTOs.Converters;
using Cookbook.Models;

namespace Cookbook.DTOs.Converters
{
    public static class RecipeConverter
    {
        public static RecipeDTO ToDTO(this Recipe recipe)
        {
            return new RecipeDTO
            {
                RecipeID = recipe.RecipeID,
                Name = recipe.Name,
                Description = recipe.Description,
                TimesLiked = recipe.TimesLiked,
                TimesFavorited = recipe.TimesFavorited,
                CookingTimeInMinutes = recipe.CookingTimeInMinutes,
                ServingsAmount = recipe.ServingsAmount,
                ImageURL = recipe.ImageURL,
                User = recipe.User.Name,
                RecipeSteps = recipe.RecipeSteps
                    .OrderBy(s => s.StepIndex)
                    .Select(s => s.Description)
                    .ToList(),
                IngredientsSections = recipe.IngredientsSections
                    .Select(s => s.ToDTO())
                    .ToList(),
                Tags = recipe.Tags
                    .Select(t => t.Name)
                    .ToList()
            };
        }
    }
}
