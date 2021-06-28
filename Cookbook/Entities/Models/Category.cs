using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Entities.Models
{
    public class Category : Entity
    {
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public string IconUrl { get; private set; }
    }

    public static class CategoryCoverter
    {
        public static CategoryDto ToDto( this Category entity )
        {
            return new CategoryDto
            {
                Title = entity.Title,
                Desc = entity.Desc,
                IconUrl = entity.IconUrl
            };
        }
    }
}