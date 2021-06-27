using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook.Entities.Models
{
    public class Category : Entity
    {
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public string IconUrl { get; private set; }
    }
}
