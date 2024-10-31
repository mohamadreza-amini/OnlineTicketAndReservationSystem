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

        public async Task<RoleDTO> CreateRole(RoleDTO roleDTO)
        {
            var role = TranslateToEntity(roleDTO);
            await _roleManager.CreateAsync(role);
            return roleDTO;

        }

        public async Task<RoleDTO> GetRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var data = TranslateToDTO(role);
            return data;
        }

        public RoleDTO TranslateToDTO(Role entity)
        {
            return entity.Adapt<RoleDTO>();
        }

        public Role TranslateToEntity(RoleDTO dto)
        {
            return dto.Adapt<Role>();
        }
    }
}
