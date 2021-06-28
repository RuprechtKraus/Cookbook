using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Entities.Models;

namespace Cookbook.Dtos
{
    public class CategoryDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string IconUrl { get; set; }
    }
}
