using DataTransferObject.DTOClasses.Contracts.Commands;
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

        public async Task<UserCommand> CreateUser(UserCommand user)
        {
            var data = TranslateToEntity(user);
            await _userManager.CreateAsync(data);
            return user;
        }

        public async Task<List<UserCommand>> GetAllUser()
        {
            List<User> data = await _userManager.Users.ToListAsync();
            List<UserCommand> result = data.Any() ? data.Select(TranslateToDTO<UserCommand>).ToList() : new List<UserCommand>();
            return result;
        }

        public DTO TranslateToDTO<DTO>(User entity)
        {
            return entity.Adapt<DTO>();
        }

      
        public User TranslateToEntity<DTO>(DTO dto)
        {
            return dto.Adapt<User>();
        }
    }
}
