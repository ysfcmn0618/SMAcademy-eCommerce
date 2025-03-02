using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
     interface IUserService
    {
        Task<IEnumerable<UserEntity>> GetAllUsers();
        Task<UserEntity> GetUserById(int id);
        Task AddUser(UserEntity product);
        Task UpdateUser(UserEntity product);
        Task DeleteUser(int id);
    }
}
