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
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(UserCommand user)
        {
            var data = user.Adapt<User>();
            data.Id = Guid.NewGuid();
            return await _userManager.CreateAsync(data, user.Password);
        }

        public async Task<List<UserCommand>> GetAllUser()
        {
            List<User> data = await _userManager.Users.ToListAsync();
            List<UserCommand> result = data.Any() ? data.Select(x => x.Adapt<UserCommand>()).ToList() : new List<UserCommand>();
            return result;
        }

        public async Task<SignInResult> PasswordSignIn(LoginCommand loginCommand)
        {
            return await _signInManager.PasswordSignInAsync(loginCommand.Email, loginCommand.Password, isPersistent: loginCommand.RememberMe, lockoutOnFailure: false);
        }

        public async Task SignIn(UserCommand userCommand)
        {
            var user = await _userManager.FindByEmailAsync(userCommand.Email);
            _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<bool> UserExist(LoginCommand loginCommand)
        {
            return await _userManager.FindByEmailAsync(loginCommand.Email) != null;
        }
    }
}
