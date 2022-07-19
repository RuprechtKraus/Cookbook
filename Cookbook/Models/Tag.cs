using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cookbook.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Recipe> Recipes { get; set; }
        [JsonIgnore]
        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
    }
}