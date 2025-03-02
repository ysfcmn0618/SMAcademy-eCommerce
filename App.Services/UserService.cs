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
    class UserService : IUserService
    {
        private readonly IGenericRepository<UserEntity> _userRepository;

        public UserService(IGenericRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddUser(UserEntity user)
        {
            await _userRepository.Add(user);
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserEntity> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task UpdateUser(UserEntity user)
        {
            await _userRepository.Update(user);
        }
    }
}
