using Cookbook.Models;

namespace Cookbook.DTOs.Converters
{
    public static class RecipeStepsConverter
    {
        public static RecipeStepDTO ToDTO(this RecipeStep recipeStep)
        {
            return new RecipeStepDTO
            {
                StepIndex = recipeStep.StepIndex,
                Description = recipeStep.Description
            };
        }
    }
}
