using DataTransferObject;
using DataTransferObject.DTOClasses.Contracts.Commands;
using DataTransferObject.DTOClasses.Results;
using Infrastructure.RepositoryInterfaces;
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
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category, int> _categoryReoistory;
        private readonly UserManager<User> _userManager;

        public CategoryService(UserManager<User> userManager, IBaseRepository<Category, int> categoryReoistory)
        {
            _userManager = userManager;
            _categoryReoistory = categoryReoistory;
        }

        public async Task<bool> AddCategory(CategoryCommand categoryDTO)
        {

            if (!string.IsNullOrWhiteSpace(categoryDTO.CategoryName) && await _userManager.FindByIdAsync(categoryDTO.CreatedUserId.ToString()) != null)
            {
                var category = categoryDTO.Adapt<Category>();
                category.CreatedDateTime = category.UpdatedDateTime = DateTime.Now;
                category.UpdatedUserId = category.CreatedUserId;
                await _categoryReoistory.CreateDataAsync(category);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            return await _categoryReoistory.DeleteDataAsync(categoryId);
        }

        public async Task<List<CategoryResult>> GetCategories()
        {
            var categories = await (await _categoryReoistory.GetAllAsync()).ToListAsync();
            return categories.Adapt<List<CategoryResult>>();
        }


    }
}
