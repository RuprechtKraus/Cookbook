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