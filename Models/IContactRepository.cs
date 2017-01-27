using System;
using System.Collections.Generic;

namespace cmkService.Models
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact Find(Guid id);
        Contact Remove(Guid id);
        void Update(Contact contact);
    }
}