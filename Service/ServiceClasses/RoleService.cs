using DataTransferObject.DTOClasses.Contracts;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RoleCommand> CreateRole(RoleCommand roleDTO)
        {
            var role = TranslateToEntity(roleDTO);
            await _roleManager.CreateAsync(role);
            return roleDTO;

        }

        public async Task<RoleCommand> GetRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var data = TranslateToDTO<RoleCommand>(role);
            return data;
        }

   
        public DTO TranslateToDTO<DTO>(Role entity)
        {
            return entity.Adapt<DTO>();
        }

        public Role TranslateToEntity(RoleCommand dto)
        {
            return dto.Adapt<Role>();
        }

        public Role TranslateToEntity<DTO>(DTO dto)
        {
            return dto.Adapt<Role>();
        }
    }
}
