using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Entities.Models;

namespace Cookbook.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string About { get; set; }

        public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}