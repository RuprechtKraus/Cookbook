using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Entities.Models;

namespace Cookbook.Entities.Models
{
    public class Tag : Entity
    {
        public string Name { get; private set; }
        public List<Recipe> Recipes { get; private set; }
    }
}
