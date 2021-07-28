using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cosmonaut;
using Cosmonaut.Extensions;
using Cosmonaut.Response;
using GraphQLSampleAPI.Data.Interfaces;
using GraphQLSampleAPI.Wrappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GraphQLSampleAPI.Data.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        protected readonly ICosmosStore<T> cosmosStore;
        public GenericRepositoryAsync(ICosmosStore<T> cosmosStore)
        {
            this.cosmosStore = cosmosStore;
        }

        public async Task<ApiResponse<T>> Add(T entity)
        {
            var result = await cosmosStore.AddAsync(entity);
            return result.IsSuccess ? new ApiResponse<T>(result.Entity, result.ResourceResponse.ToString()) : new ApiResponse<T>(result.Exception.Message);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await cosmosStore.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await cosmosStore.Query().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await cosmosStore.Query().ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            var data = await cosmosStore.FindAsync(id);
            return data;
        }

        public async Task Remove(T entity)
        {
            await cosmosStore.RemoveAsync(entity);
        }

        public async Task RemoveById(string id)
        {
            await cosmosStore.RemoveByIdAsync(id);
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            await cosmosStore.RemoveRangeAsync(entities);
        }

        public async Task Update(T entity)
        {
            await cosmosStore.UpdateAsync(entity);
        }

        public async Task UpdateRange(IEnumerable<T> entities)
        {
            await cosmosStore.UpdateRangeAsync(entities);
        }

        public async Task Upsert(T entity)
        {
            await cosmosStore.UpsertAsync(entity);
        }

        public async Task UpsertRange(IEnumerable<T> entities)
        {
            await cosmosStore.UpsertRangeAsync(entities);
        }
    }

}