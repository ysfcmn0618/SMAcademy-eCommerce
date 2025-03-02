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
    class RoleService : IRoleService
    {
        private readonly IGenericRepository<RoleEntity> _roleRepository;

        public RoleService(IGenericRepository<RoleEntity> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task AddRole(RoleEntity role)
        {
            await _roleRepository.Add(role);
        }

        public async Task DeleteRole(int id)
        {
            await _roleRepository.Delete(id);
        }

        public async Task<IEnumerable<RoleEntity>> GetAllRoles()
        {
            return await _roleRepository.GetAll();
        }

        public async Task<RoleEntity> GetRoleById(int id)
        {
            return await _roleRepository.GetById(id);
        }

        public async Task UpdateRole(RoleEntity role)
        {
            await _roleRepository.Update(role);
        }
    }
}
