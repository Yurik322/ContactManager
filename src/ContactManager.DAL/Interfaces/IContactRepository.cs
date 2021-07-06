using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.DAL.Entities;

namespace ContactManager.DAL.Interfaces
{
    /// <summary>
    /// Interface of repository that work with contacts.
    /// </summary>
    public interface IContactRepository : IRepositoryBase<Contact>
    {
    }
}
