using System;
using Cookbook.DAL.Repositories;
using Cookbook.Models;
using Cookbook.DAL.DbInfrastructure;

namespace Cookbook.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly CookbookContext _context = new CookbookContext();
        private CategoryRepository _categoryRepository;
        private UserRepository _userRepository;
        private RecipeRepository _recipeRepository;
        private bool _disposed = false;

        public CategoryRepository CategoryRepository
        {
            get 
            { 
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public RecipeRepository RecipeRepository
        {
            get
            {
                if (_recipeRepository == null)
                {
                    _recipeRepository = new RecipeRepository(_context);
                }
                return _recipeRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}