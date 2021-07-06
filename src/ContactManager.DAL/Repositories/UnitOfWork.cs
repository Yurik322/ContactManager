using System.Threading.Tasks;
using ContactManager.DAL.EF;
using ContactManager.DAL.Interfaces;

namespace ContactManager.DAL.Repositories
{
    /// <summary>
    /// Unit of Work pattern simplifies working with different repositories for getting data from repository.
    /// It Helps work with data context.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _repositoryContext;
        private IContactRepository _contactRepository;
        private bool _disposedValue;

        public UnitOfWork(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        
        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                    _contactRepository = new ContactRepository(_repositoryContext);

                return _contactRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _repositoryContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}