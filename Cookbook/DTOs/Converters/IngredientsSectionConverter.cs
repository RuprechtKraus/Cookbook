using Cookbook.Models;

namespace Cookbook.DTOs.Converters
{
    public static class IngredientsSectionConverter
    {
        public static IngredientsSectionDTO ToDTO(this IngredientsSection section)
        {
            return new IngredientsSectionDTO
            {
                Name = section.Name,
                Products = section.Products
            };
        }
    }
}
