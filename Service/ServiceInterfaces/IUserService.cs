using DataTransferObject;
using DataTransferObject.DTOClasses.Contracts.Commands;
using Microsoft.AspNetCore.Identity;
using Model;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IUserService 
    {
        Task<IdentityResult> CreateUser(UserCommand user);
        Task<List<UserCommand>> GetAllUser();
        Task SignIn(UserCommand userCommand);     
        Task<SignInResult> PasswordSignIn(LoginCommand loginCommand);
        Task<bool> UserExist(LoginCommand loginCommand);
    }
}
