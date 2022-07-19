namespace Cookbook.DTOs
{
    public class UserAuthenticatedDTO
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
