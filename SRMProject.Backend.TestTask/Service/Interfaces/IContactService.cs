using PagedList;
using SRMProject.Backend.TestTask.Entity;

namespace SRMProject.Backend.TestTask.Service.Interfaces
{
    public interface IContactService
    {

        public Task<object> GetPageListContact(int pageNumber = 1);
        public Task<List<Contact>> GetContact();
        public Task<Contact> UpdateContact(Contact contact);
        public void InsertContact(Contact contact);
        public void DeleteContact(Guid id);
    }
}
