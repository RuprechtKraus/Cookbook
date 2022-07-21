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
                UserID = recipe.UserID,
                User = recipe.User.Login,
                RecipeSteps = recipe.RecipeSteps
                    .OrderBy(s => s.StepIndex)
                    .Select(s => s.ToDTO())
                    .ToList(),
                IngredientsSections = recipe.IngredientsSections
                    .Select(s => s.ToDTO())
                    .ToList(),
                Tags = recipe.Tags
                    .Select(t => t.Name)
                    .ToList()
            };
        }

        public static RecipePreviewDTO ToPreviewDTO(this Recipe recipe)
        {
            return new RecipePreviewDTO
            {
                RecipeID = recipe.RecipeID,
                User = recipe.User.Login,
                Name = recipe.Name,
                Description = recipe.Description,
                CookingTimeInMinutes = recipe.CookingTimeInMinutes,
                ServingsAmount = recipe.ServingsAmount,
                TimesLiked = recipe.TimesLiked,
                TimesFavorited = recipe.TimesFavorited,
                ImageURL = recipe.ImageURL,
                Tags = recipe.Tags.Select(t => t.Name).ToList()
            };
        }
    }
}
