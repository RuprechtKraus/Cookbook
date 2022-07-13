using System;
using System.Collections.Generic;

namespace Cookbook.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public int RecipesCount { get; set; }
        public int LikesCount { get; set; }
        public int FavoritesCount { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}