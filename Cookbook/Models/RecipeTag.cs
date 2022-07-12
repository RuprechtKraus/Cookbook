using System.Collections.Generic;

namespace Cookbook.Models
{
    public class RecipeTag
    {
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }

        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }
    }
}