using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ContactManager.DAL.EF;
using ContactManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.DAL.Repositories
{
    /// <summary>
    /// Base repository that have methods for all repositories.
    /// </summary>
    /// <typeparam name="TEntity">parameter of model name.</typeparam>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected ApplicationDbContext RepositoryContext;

        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public virtual async Task<IEnumerable<TEntity>> ListItemsAsync()
        {
            return await RepositoryContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetItemAsync(int id)
        {
            return await RepositoryContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task CreateAsync(TEntity item)
        {
            await RepositoryContext.Set<TEntity>().AddAsync(item);
        }

        public virtual void Update(TEntity model)
        {
            RepositoryContext.Set<TEntity>().Update(model);
        }

        public virtual void Delete(TEntity item)
        {
            RepositoryContext.Set<TEntity>().Remove(item);
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            Delete(await GetItemAsync(id));
        }

        public virtual async Task SaveAsync()
        {
            await RepositoryContext.SaveChangesAsync();
        }
    }
}
