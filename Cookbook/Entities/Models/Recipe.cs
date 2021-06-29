using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Dtos;
using Cookbook.DbInfrastructure;
using Cookbook.Entities.Models;
using System.Text.Json.Serialization;

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

    public static class RecipeConverter
    {
        public static RecipeToLoadDto ToRecipeToLoadDto( this Recipe entity, User owner )
        {
            return new RecipeToLoadDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Desc = entity.Desc,
                User = owner.Login,
                CookingTime = entity.CookingTime,
                Servings = entity.Servings,
                Tags = entity.Tags,
                Likes = entity.Likes,
                Favs = entity.Favs,
                ImageUrl = entity.ImageUrl
            };
        }

        public static RecipeToEditDto ToRecipeToSaveDto( this Recipe entity, User owner )
        {
            return new RecipeToEditDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Desc = entity.Desc,
                User = owner.Login,
                CookingTime = entity.CookingTime,
                Servings = entity.Servings,
                Tags = entity.Tags,
                Ingredients = entity.Ingredients,
                Steps = entity.Steps
            };
        }
    }
}
