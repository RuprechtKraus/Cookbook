using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Entities.Models
{
    public class Recipe : Entity
    {
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public int Likes { get; private set; }
        public int Favs { get; private set; }
        public int CookingTime { get; private set; }
        public int Servings { get; private set; }
        public string ImageUrl { get; private set; }
        public int UserId { get; private set; }

        public List<Tag> Tags { get; private set; } = new List<Tag>();
        public List<IngredientsGroup> Ingredients { get; private set; }  = new List<IngredientsGroup>();
        public List<Step> Steps { get; private set; } = new List<Step>();
    }
}
