namespace Cookbook.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string About { get; set; }
        public int RecipesCount { get; set; }
        public int LikesCount { get; set; }
        public int FavoritesCount { get; set; }
    }
}
