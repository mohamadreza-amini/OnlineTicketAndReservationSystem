using DataTransferObject;
using DataTransferObject.DTOClasses.Contracts;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IRoleService
    {
        Task<RoleCommand> GetRole(Guid id);
        Task<RoleCommand> CreateRole(RoleCommand roleDTO);
    }
}
