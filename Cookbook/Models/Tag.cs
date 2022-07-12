using System.Collections.Generic;

namespace Cookbook.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeTag> RecipeTags { get; set; }
    }
}