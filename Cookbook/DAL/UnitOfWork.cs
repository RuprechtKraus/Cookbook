using System;
using Cookbook.DAL.Repositories;
using Cookbook.Models;
using Cookbook.DAL.DbInfrastructure;

namespace Cookbook.DAL
{
    public class UnitOfWork : IDisposable
    {
        private CookbookContext _context = new CookbookContext();
        private BaseRepository<Category> _categoryRepository;
        private bool _disposed = false;

        public BaseRepository<Category> CategoryRepository
        {
            get 
            { 
                if (_categoryRepository == null)
                {
                    _categoryRepository = new BaseRepository<Category>(_context);
                }
                return _categoryRepository;
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