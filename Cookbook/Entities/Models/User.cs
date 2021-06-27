using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
}