﻿using Catalogue.Core.Entities;
using Catalogue.Core.Interfaces;
using Catalogue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CatalogueContext _context;
        private DbSet<T> _entities;


        public BaseRepository(CatalogueContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }


        public async Task Update(T entity)
        {
            _entities.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            T entity = await GetById(id);

            _entities.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
