using System;
using System.Threading.Tasks;

namespace ContactManager.DAL.Interfaces
{
    /// <summary>
    /// Interface for getting lists from data context.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository ContactRepository { get; }
        Task SaveAsync();
    }
}
