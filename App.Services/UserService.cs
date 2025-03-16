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
    public class UserService : BaseDbService<UserEntity>
    {
        private readonly IGenericRepository<UserEntity> _userRepository;

        public UserService(IGenericRepository<UserEntity> userRepository):base (userRepository)
        {
            _userRepository = userRepository;
        }
       
        public async Task<IEnumerable<UserEntity?>> GetUserWithDetailsAsync()
        {
            return await _userRepository.GetAllIncludingAsync(
                p => p.Role
            );
        }
    }
}
