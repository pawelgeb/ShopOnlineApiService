using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsDTO;
using ShopOnlineApi.ModelsSQL;
using ShopOnlineApi.Repositories.Interfaces;

namespace ShopOnlineApi.Repositories
{
    public class ContactRepository:IContactRepository
    {
        private readonly ShopContext _context;
        public ContactRepository(ShopContext context)
        {
            _context = context;
        }
        public async Task<ContactDTO> CreateItem(ContactDTO contactDTO)
        {
            var contactItem = new Contact
            {
                Id = contactDTO.Id,
                PhoneNumber = contactDTO.PhoneNumber,
                EmailAdress = contactDTO.EmailAdress,
                UserId = contactDTO.UserId
            };
            _context.Contacts.Add(contactItem);
            await _context.SaveChangesAsync();
            return contactDTO;
        }
        public async Task DeleteItem(int id)
        {
            var contactItem = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contactItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ContactDTO>> GetAll()
        {
            var contactItem = await _context.Contacts
            .Select(x => ContactDTO(x))
            .ToListAsync();
            return contactItem;
        }
        public async Task<ContactDTO> GetItem(int id)
        {
            var contactItem = await _context.Contacts.FindAsync(id);
            return ContactDTO(contactItem);
        }
        public async Task UpdateItem(ContactDTO contactDTO, int id)
        {
            {
                var contactItem = await _context.Contacts.FindAsync(id);
                contactItem.Id = contactDTO.Id;
                contactItem.PhoneNumber = contactDTO.PhoneNumber;
                contactItem.EmailAdress = contactDTO.EmailAdress;
                contactItem.UserId = contactDTO.UserId;
                await _context.SaveChangesAsync();
            }
        }
        private static ContactDTO ContactDTO(Contact contact) => new ContactDTO
        {
            Id = contact.Id,
            PhoneNumber = contact.PhoneNumber,
            EmailAdress = contact.EmailAdress,
            UserId = contact.UserId
        };
    }
}
