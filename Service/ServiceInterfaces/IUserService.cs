using DataTransferObject;
using DataTransferObject.DTOClasses.Contracts.Commands;
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
        Task<UserCommand> CreateUser(UserCommand user);
        Task<List<UserCommand>> GetAllUser();
    }
}
