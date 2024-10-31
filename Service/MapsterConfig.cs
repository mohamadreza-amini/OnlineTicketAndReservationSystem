using DataTransferObject.DTOClasses;
using DataTransferObject.DTOClasses.Contracts;
using Mapster;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MapsterConfig
    {
        public static void RegisterMapping()
        {
            TypeAdapterConfig<Role, RoleDTO>.NewConfig()
                .Map(x => x.Description, x => x.RoleDescription)
                .Map(x => x.EnglishName, x => x.RoleName)
                .Map(x => x.PersianName, x => x.RolePersianName);
            TypeAdapterConfig<User, UserDTO>.NewConfig()
               .Map(x => x.FirstName, x => x.FirstName)
               .Map(x => x.LastName, x => x.LastName)
               .Map(x => x.Email, x => x.Email)
               .Map(x => x.Password, x => x.PasswordHash)
               .Map(x => x.ConfirmPassword, x => x.PasswordHash)
               .Map(x => x.Email, x => x.UserName);
            TypeAdapterConfig<UserDTO, User>.NewConfig()
               .Map(x => x.FirstName, x => x.FirstName)
               .Map(x => x.LastName, x => x.LastName)
               .Map(x => x.Email, x => x.Email)
               .Map(x => x.PasswordHash, x => x.Password)
               .Map(x => x.PasswordHash, x => x.ConfirmPassword)
               .Map(x => x.UserName, x => x.Email);
        }
    }
}
