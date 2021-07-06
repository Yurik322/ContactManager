using System.Collections.Generic;
using System.Threading.Tasks;
using ContactManager.BLL.DTO;

namespace ContactManager.BLL.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllContactsAsync();

        Task<ContactDto> GetContactById(int contactId);

        Task AddNewContactAsync(ContactDto contactDto);

        Task EditContactAsync(ContactDto contactDto);

        Task DeleteContactAsync(int contactId);

        void AddCsvFile(string dbPath);
    }
}
