using System.Collections.Generic;

namespace Cookbook.Models
{
    public class Recipe
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
        public virtual User User { get; set; }
        public virtual ICollection<RecipeStep> RecipeSteps { get; set; }
        public virtual ICollection<IngredientsSection> IngredientsSections { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
    }
}