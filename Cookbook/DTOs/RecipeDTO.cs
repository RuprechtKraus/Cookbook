using Cookbook.Models;
using System.Collections.Generic;

namespace Cookbook.DTOs
{
    public class RecipeDTO
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimesLiked { get; set; }
        public int TimesFavorited { get; set; }
        public int CookingTimeInMinutes { get; set; }
        public int ServingsAmount { get; set; }
        public string ImageURL { get; set; }
        public int UserID { get; set; }
        public string User { get; set; }
        public ICollection<string> Tags { get; set; }
        public ICollection<RecipeStepDTO> RecipeSteps { get; set; }
        public ICollection<IngredientsSectionDTO> IngredientsSections { get; set; }
    }
}
