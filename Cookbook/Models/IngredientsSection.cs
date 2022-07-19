using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cookbook.Models
{
    public class IngredientsSection
    {
        public int IngredientsSectionID { get; set; }
        public string Name { get; set; }
        public string Products { get; set; }

        public int RecipeID { get; set; }

        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }
    }
}