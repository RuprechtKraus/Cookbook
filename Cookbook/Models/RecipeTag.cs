using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cookbook.Models
{
    public class RecipeTag
    {
        public int RecipeID { get; set; }

        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }

        public int TagID { get; set; }

        [JsonIgnore]
        public virtual Tag Tag { get; set; }
    }
}