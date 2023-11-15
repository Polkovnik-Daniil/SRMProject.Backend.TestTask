using Microsoft.AspNetCore.Mvc;
using SRMProject.Backend.TestTask.Entity;
using SRMProject.Backend.TestTask.Service.Interfaces;

namespace SRMProject.Backend.TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService) => _contactService = contactService;
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetPage(int pageNumber = 1)
        {
            var result = await _contactService.GetPageListContact(pageNumber);
            return Ok(result);
        }
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert(Contact contact)
        {
            _contactService.InsertContact(contact);
            return Ok();
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Contact contact)
        {
            var result = _contactService.UpdateContact(contact);
            return Ok(result.Result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _contactService.DeleteContact(id);
            return Ok();
        }
    }
}
