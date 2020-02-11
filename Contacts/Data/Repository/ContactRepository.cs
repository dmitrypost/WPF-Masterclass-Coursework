using Contacts.Interfaces;
using Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        public IEnumerable<Contact> GetContacts()
        {
            try
            {
                using (var context = new AppDbContext())
                    return context.Contacts.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Contact GetContact(int id)
        {
            try
            {
                using (var context = new AppDbContext())
                    return context.Contacts.SingleOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public int UpsertContact(Contact contact)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var contactInDb = context.Contacts.SingleOrDefault(x => x.Id == contact.Id);

                    if (contactInDb == null)
                    {
                        context.Contacts.Add(contact);
                        context.SaveChanges();
                        return contact.Id;
                    }

                    contactInDb.Name = contact.Name;
                    contactInDb.Phone = contact.Phone;
                    contactInDb.Email = contact.Email;
                    context.SaveChanges();
                    return contactInDb.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteContact(int contactId)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var contactInD = context.Contacts.SingleOrDefault(x => x.Id == contactId);

                    if (contactInD == null) return;
                    
                    context.Contacts.Remove(contactInD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
