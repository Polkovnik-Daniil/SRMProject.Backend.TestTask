using SRMProject.Backend.TestTask.Entity;
using SRMProject.Backend.TestTask.Database;
using SRMProject.Backend.TestTask.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using PagedList;

namespace SRMProject.Backend.TestTask.Service
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly int _countElementPage = 10;
        public ContactService(ApplicationDbContext applicationDbContext) =>
            _applicationDbContext = applicationDbContext;
        public Task<List<Contact>> GetContact() => Task.FromResult(_applicationDbContext.Contacts.ToList());
        public async Task<object> GetPageListContact(int pageNumber)
        {
            var page = _applicationDbContext.Contacts.OrderBy(p => p.Name).ToPagedList(pageNumber, _countElementPage);
            int count = await _applicationDbContext.Contacts.CountAsync();
            int countPage = count % 20 == 0 ? (count / _countElementPage) : ((count / _countElementPage) + 1);
            foreach (Contact item in page)
            {
                Console.WriteLine($"{item.Name} - {item.MobilePhone} - {item.BirthDate}");
            }
            return new { page, countPage };
        }

        public void DeleteContact(Guid id)
        {
            var entity = _applicationDbContext.Contacts.Where(e => e.Id == id).First();
            _applicationDbContext.Contacts.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void InsertContact(Contact contact)
        {
            _applicationDbContext.Contacts.Add(contact);
            _applicationDbContext.SaveChanges();
        }

        public Task<Contact> UpdateContact(Contact contact)
        {
            _applicationDbContext.Entry(contact).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return Task.FromResult(contact);
        }

    }
}
