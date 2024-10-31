using DataTransferObject.DTOClasses.Contracts;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class CategoryService:ICategoryService
    {
        public Task<bool> AddCategory(CategoryDTO addCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO TranslateToDTO(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category TranslateToEntity(CategoryDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
