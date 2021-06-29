using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Entities.Models
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string About { get; private set; }

        public List<Recipe> Recipes { get; private set; } = new List<Recipe>();
    }

    public static class UserConverter
    {
        public static UserDto ToDto( this User entity )
        {
            return new UserDto
            {
                Name = entity.Name,
                Login = entity.Login,
                Password = entity.Password,
                About = entity.About,
                Recipes = entity.Recipes
            };
        }
    }
}