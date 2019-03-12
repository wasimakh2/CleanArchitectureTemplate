﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Shared;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Shared
{
    public class EfRepository<TEntity> : IRepository<TEntity>
         where TEntity : EntityBase
    {
        private readonly AppDbContext dbContext;

        public EfRepository(AppDbContext appDbContext) =>
            this.dbContext = appDbContext;

        public async Task<IEnumerable<TEntity>> GetItemsAsync(ICacheableDataSpecification<TEntity> specification) =>
            await dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .ToListAsync()
            .ConfigureAwait(false);

        public async Task<int> GetItemCountAsync(ICacheableDataSpecification<TEntity> specification) =>
            await dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .CountAsync()
            .ConfigureAwait(false);

        public async Task<TEntity> GetSingleItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .SingleOrDefaultAsync()
            .ConfigureAwait(false);

        public async Task<TEntity> GetFirstItemAsync(ICacheableDataSpecification<TEntity> specification) =>
            await dbContext
            .Set<TEntity>()
            .ExeSpec(specification.Specification)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        public async Task UpdateAsync(TEntity updatedItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
