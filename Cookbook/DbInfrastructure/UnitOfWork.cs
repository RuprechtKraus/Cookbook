using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Repositories;

namespace Cookbook.DbInfrastructure
{
    public class UnitOfWork : IDisposable
    {
        private CookbookDbContext _db = new CookbookDbContext();
        private CategoryRepository _categoryRepository;
        private UserRepository _userRepository;
        private RecipeRepository _recipeRepository;
        private TagRepository _tagRepository;
        private bool _disposed = false;

        public CategoryRepository Categories
        {
            get
            {
                if ( _categoryRepository == null )
                    _categoryRepository = new CategoryRepository( _db );
                return _categoryRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if ( _userRepository == null )
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }

        public RecipeRepository Recipes
        {
            get
            {
                if ( _recipeRepository == null )
                    _recipeRepository = new RecipeRepository( _db );
                return _recipeRepository;
            }
        }

        public TagRepository Tags
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new TagRepository( _db );
                return _tagRepository;
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose( bool disposing )
        {
            if ( !_disposed )
            {
                if ( disposing )
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
    }
}
