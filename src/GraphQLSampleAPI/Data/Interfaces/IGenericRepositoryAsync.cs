using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GraphQLSampleAPI.Wrappers;

namespace GraphQLSampleAPI.Data.Interfaces
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<ApiResponse<T>> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveById(string id);
        Task RemoveRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task Upsert(T entity);
        Task UpsertRange(IEnumerable<T> entities);
    }
}