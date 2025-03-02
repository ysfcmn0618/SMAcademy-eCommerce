using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
     interface IRoleService
    {
        Task<IEnumerable<RoleEntity>> GetAllRoles();
        Task<RoleEntity> GetRoleById(int id);
        Task AddRole(RoleEntity role);
        Task UpdateRole(RoleEntity role);
        Task DeleteRole(int id);
    }
}
