using DataTransferObject.DTOClasses.Contracts.Commands;
using DataTransferObject.DTOClasses.Results;
using Mapster;
using Model.Entities;
using Shared.Enums;
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
            /*TypeAdapterConfig<Role, RoleCommand>.NewConfig()
                .Map(x => x.Description, x => x.RoleDescription)
                .Map(x => x.EnglishName, x => x.RoleName)
                .Map(x => x.PersianName, x => x.RolePersianName);*/
            
            /*TypeAdapterConfig<UserCommand, User>.NewConfig()
               .Map(x => x.FirstName, x => x.FirstName)
               .Map(x => x.LastName, x => x.LastName)
               .Map(x => x.Email, x => x.Email)
               .Map(x => x.PasswordHash, x => x.Password)
               .Map(x => x.PasswordHash, x => x.ConfirmPassword)
               .Map(x => x.UserName, x => x.Email);*/


            /*TypeAdapterConfig<CategoryCommand, Category>.NewConfig()
                .Map(x => x.UpdatedDateTime, y => DateTime.Now)
                .Map(x => x.CreatedDateTime, y => DateTime.Now)
                .Map(x => x.UpdatedDateTime, y => DateTime.Now)
                .Map(x => x.UpdatedDateTime, y => DateTime.Now);*/


            TypeAdapterConfig<Ticket, TicketResult>.NewConfig()
              .Map(x => x.CategoryName, y => y.Category.CategoryName);

            TypeAdapterConfig<User, UserCommand>.NewConfig()  
               .Map(x => x.Email, x => x.UserName)
               .Map(x=>x.BlobCommand,x=>x.Blob.Adapt<BlobCommand>());

            TypeAdapterConfig<UserCommand, User>.NewConfig()
               .Map(x => x.UserName, x => x.Email)
                .Map(x => x.Blob, x => x.BlobCommand.Adapt<Blob>());

            TypeAdapterConfig<CategoryCommand, Category>.NewConfig()
               .Map(x => x.CreatedUserId, x => x.CreatedUserId);


            TypeAdapterConfig<Blob, BlobCommand>.NewConfig()
                .Map(x=>x.MimeType,x=>x.MimeType)
                .Map(x=>x.FileAddress,x=>x.FileAddress)
                .Map(x=>x.FileSize,x=>x.FileSize);


            TypeAdapterConfig<BlobCommand, Blob>.NewConfig()
                 .Map(x => x.MimeType, x => x.MimeType)
                .Map(x => x.FileAddress, x => x.FileAddress)
                .Map(x => x.FileSize, x => x.FileSize); ;

            TypeAdapterConfig<Category, CategoryCommand>.NewConfig()
                .Map(x => x.TicketCategory, x => (TicketCategory)x.CategoryType);

            TypeAdapterConfig<CategoryCommand, Category>.NewConfig()
               .Map(x => x.CategoryType, x => (byte)x.TicketCategory);


        }
    }
}
