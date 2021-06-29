using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Entities.Models;

namespace Cookbook.Dtos
{
    abstract public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string User { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }

    sealed public class RecipeToLoadDto : RecipeDto
    {
        public int Likes { get; set; }
        public int Favs { get; set; }
        public string ImageUrl { get; set; }
    }

    sealed public class RecipeToEditDto : RecipeDto
    {
        public List<IngredientsGroup> Ingredients { get; set; } = new List<IngredientsGroup>();
        public List<Step> Steps { get; set; } = new List<Step>();
    }
}
