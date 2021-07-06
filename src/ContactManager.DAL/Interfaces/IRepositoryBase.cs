using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactManager.DAL.Interfaces
{
    /// <summary>
    /// IRepositoryBase pattern for encapsulating the logic of working with data sources.
    /// </summary>
    /// <typeparam name="TEntity">parameter of model name.</typeparam>
    public interface IRepositoryBase<TEntity>
    {
        Task<IEnumerable<TEntity>> ListItemsAsync();
        Task<TEntity> GetItemAsync(int id);
        Task CreateAsync(TEntity item);
        void Update(TEntity model);
        void Delete(TEntity item);
        Task DeleteByIdAsync(int id);
        Task SaveAsync();
    }
}
