using DataTransferObject.DTOClasses;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            var data = TranslateToEntity(user);
            await _userManager.CreateAsync(data);
            return user;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            List<User> data = await _userManager.Users.ToListAsync();
            List<UserDTO> result = data.Any() ? data.Select(TranslateToDTO).ToList() : new List<UserDTO>();
            return result;

        }

        public UserDTO TranslateToDTO(User entity)
        {
            return entity.Adapt<UserDTO>();
        }

        public User TranslateToEntity(UserDTO dto)
        {
            return dto.Adapt<User>();
        }
    }
}
