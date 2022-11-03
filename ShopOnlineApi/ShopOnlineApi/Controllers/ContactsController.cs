using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ShopContext context;
        public ContactsController(ShopContext shopContext)
        {
            context = shopContext;
        }
        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<List<ContactDTO>>> Get()
        {
            return await context.Contacts
            .Select(x => ContactDTO(x))
            .ToListAsync();
        }
        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> GetContact(int id)
        {
            var contactItem = await context.Contacts.FindAsync(id);
            if (contactItem == null)
            {
                return NotFound();
            }
            return ContactDTO(contactItem);
        }
        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConctactItem(int id, ContactDTO contactDTO)
        {
            if (id != contactDTO.Id)
            {
                return BadRequest();
            }
            var contactItem = await context.Contacts.FindAsync(id);
            if (contactItem == null)
            {
                return NotFound();
            }
            contactItem.Id = contactDTO.Id;
            contactItem.EmailAdress = contactDTO.EmailAdress;
            contactItem.PhoneNumber = contactDTO.PhoneNumber;
            contactItem.UserId = contactDTO.UserId;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ContactExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }
        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactDTO>> PostContact(ContactDTO contactDTO)
        {
            var contactItem = new Contact
            {
                Id = contactDTO.Id,
                EmailAdress = contactDTO.EmailAdress,
                PhoneNumber = contactDTO.PhoneNumber,
                UserId = contactDTO.UserId
            };

            context.Contacts.Add(contactItem);
            await context.SaveChangesAsync();
            return CreatedAtAction(
                nameof(GetContact),
                new
                {
                    id = contactItem.Id
                },
                ContactDTO(contactItem));

            return CreatedAtAction("GetContact", new { id = contactDTO.UserId }, contactDTO);
        }
        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
            return NoContent();
        }

        private bool ContactExists(int id)
        {
            return context.Contacts.Any(e => e.UserId == id);
        }
        private static ContactDTO ContactDTO(Contact contact) => new ContactDTO
        {
            Id = contact.Id,
            EmailAdress = contact.EmailAdress,
            PhoneNumber = contact.PhoneNumber,
            UserId = contact.UserId,
        };
    }
}
