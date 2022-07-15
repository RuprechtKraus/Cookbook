using System;
using System.Linq;
using Cookbook.DTOs;
using Cookbook.Models;
using Cookbook.Exceptions;
using Cookbook.DAL.DbInfrastructure;

namespace Cookbook.DAL.Repositories
{
    public class UserRepository :  Repository<User>
    {
        public UserRepository(CookbookContext context)
            : base(context) 
        { 
        }

        public void Register(UserRegisterDTO user)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new RegistrationException("Password is empty");
            }

            if (_dbSet.Any(x => x.Login == user.Login))
            {
                throw new RegistrationException("Login \"" + user.Login + "\" is already taken");
            }

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            _dbSet.Add(new User
            {
                Name = user.Name,
                Login = user.Login,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            });
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Value cannot be empty of whitespace only string", 
                    nameof(password));
            }

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
