using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Entities.Models
{
    public class Step : Entity
    {
        public int StepIndex { get; private set; }
        public string Desc { get; private set; }
        public int RecipeId { get; private set; }
    }
}
