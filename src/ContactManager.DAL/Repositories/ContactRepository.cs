using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.DAL.EF;
using ContactManager.DAL.Entities;
using ContactManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.DAL.Repositories
{
    /// <summary>
    /// Class repository for work with contacts.
    /// </summary>
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
