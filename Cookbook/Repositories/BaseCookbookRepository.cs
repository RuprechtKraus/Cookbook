﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Repositories
{
    abstract public class BaseCookbookRepository<EntityType>
        : IRepository<EntityType> where EntityType : Entities.Entity
    {
        private readonly DbInfrastructure.CookbookDbContext _context;
        protected DbSet<EntityType> Entities => _context.Set<EntityType>();

        public BaseCookbookRepository(DbInfrastructure.CookbookDbContext context)
        {
            _context = context;
        }

        public List<EntityType> GetAll() => Entities.ToList();

        public EntityType Get(int id) => Entities.Find( id );

        public void Remove( EntityType entityToDelete )
        {
            Entities.Remove( entityToDelete );
        }
    }
}