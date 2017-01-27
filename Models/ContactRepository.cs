using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace cmkService.Models
{
    public class ContactRepository : IContactRepository
    {
        private static ConcurrentDictionary<Guid, Contact> _contacts =
            new ConcurrentDictionary<Guid, Contact>();
        
        public ContactRepository()
        {
            Add(new Contact { Name = "Christopher", Email = "cm.kanode@gmail.com", Phone = "770", IsActive = true });
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Values;
        }

        public void Add(Contact contact)
        {
            contact.Id = Guid.NewGuid();
            _contacts[contact.Id] = contact;
        }

        public Contact Find(Guid id)
        {
            Contact contact;
            _contacts.TryGetValue(id, out contact);
            return contact;
        }

        public Contact Remove(Guid id)
        {
            Contact contact;
            _contacts.TryRemove(id, out contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }
    }
}