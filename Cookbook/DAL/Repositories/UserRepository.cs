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

        public User Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _dbSet.SingleOrDefault(x => x.Login == login);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
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

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Value cannot be empty of whitespace only string",
                    nameof(password));
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected)", 
                    nameof(storedHash));
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", 
                    nameof(storedSalt));
            }

            using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return AreHashesEqual(computedHash, storedHash);
        }

        private static bool AreHashesEqual(byte[] left, byte[] right)
        {
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
