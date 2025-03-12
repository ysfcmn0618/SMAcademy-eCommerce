using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices
{
    public class ContactFormService : IContactFormService
    {
        private readonly IGenericRepository<ContactFormEntity> _contatFormService;
        public ContactFormService(IGenericRepository<ContactFormEntity> genericRepository)
        {
            _contatFormService = genericRepository;
        }
        public async Task AddContactForm(ContactFormEntity contactForm)
        {
            await _contatFormService.Add(contactForm);
        }

        public async Task DeleteContactFormById(int id)
        {
            await _contatFormService.Delete(id);
        }

        public async Task<ContactFormEntity> GetContactFormById(int id)
        {
            return await _contatFormService.GetById(id);
        }

        public async Task<IEnumerable<ContactFormEntity>> GetContactForms()
        {
            return await _contatFormService.GetAll();
        }

        public async Task UpdateContactForm(ContactFormEntity contactForm)
        {
            await _contatFormService.Update(contactForm);
        }
    }
}
