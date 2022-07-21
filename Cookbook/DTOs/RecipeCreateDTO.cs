using System.Collections.Generic;
using Cookbook.Models;

namespace Cookbook.DTOs
{
    public class RecipeCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CookingTimeInMinutes { get; set; }
        public int ServingsAmount { get; set; }
        public int UserID { get; set; }
        public string User { get; set; }
        public ICollection<IngredientsSectionDTO> IngredientsSections { get; set; }
        public ICollection<RecipeStepDTO> RecipeSteps { get; set; }
        public ICollection<string> Tags { get; set; }
        public string ImageBase64 { get; set; }
    }
}
