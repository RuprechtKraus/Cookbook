using System.Collections.Generic;

namespace Cookbook.Models
{
    public class IngredientsSection
    {
        public int IngredientsSectionID { get; set; }
        public string Name { get; set; }
        public string Products { get; set; }

        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}