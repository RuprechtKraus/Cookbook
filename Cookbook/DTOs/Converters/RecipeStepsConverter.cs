using Cookbook.Models;

namespace Cookbook.DTOs.Converters
{
    public static class RecipeStepConverter
    {
        public static RecipeStepDTO ToDTO(this RecipeStep recipeStep)
        {
            return new RecipeStepDTO
            {
                StepIndex = recipeStep.StepIndex,
                Description = recipeStep.Description
            };
        }

        public static RecipeStep ToRecipeStep(this RecipeStepDTO dto)
        {
            return new RecipeStep
            {
                StepIndex = dto.StepIndex,
                Description = dto.Description
            };
        }
    }
}
