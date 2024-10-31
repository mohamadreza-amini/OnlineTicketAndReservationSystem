using DataTransferObject.DTOClasses.Contracts;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface ICategoryService:IServiceBase<Category,CategoryDTO,int>
{
    Task<bool> AddCategory(CategoryDTO addCategoryDTO);
    Task<bool> DeleteCategory(int categoryId);

}
