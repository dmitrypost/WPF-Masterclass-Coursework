using System.Collections.Generic;
using Contacts.Models;

namespace Contacts.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(int id);
        int UpsertContact(Contact contact);
        void DeleteContact(int contactId);
    }
}