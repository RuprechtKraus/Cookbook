using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Entities.Models
{
    public class IngredientsGroup : Entity
    {
        public string Title { get; private set; }
        public string List { get; private set; }
        public int RecipeId { get; private set; }
    }
}
