using System.Linq;
using Cookbook.DTOs;
using Cookbook.Models;

namespace Cookbook.DTOs.Converters
{
    public static class RecipePreviewConverter
    {
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
