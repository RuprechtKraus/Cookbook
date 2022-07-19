using System.Collections.Generic;

namespace Cookbook.DTOs
{
    public class IngredientsSectionDTO
    {
        public string Name { get; set; }
        public ICollection<string> Products { get; set; }
    }
}
