using Cookbook.Models;

namespace Cookbook.DTOs.Converters
{
    public static class UserConverter
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO
            {
                Name = user.Name,
                Login = user.Login,
                About = user.About,
                RecipesCount = user.RecipesCount,
                LikesCount = user.LikesCount,
                FavoritesCount = user.FavoritesCount
            };
        }
    }
}
