using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IContactFormService
    {
        Task AddContactForm(ContactFormEntity contactForm);
        Task<ContactFormEntity> GetContactFormById(int id);
        Task<IEnumerable<ContactFormEntity>> GetContactForms();
        Task UpdateContactForm(ContactFormEntity contactForm);
        Task DeleteContactFormById(int id);
    }
}
