using DataTransferObject;
using DataTransferObject.DTOClasses.Contracts.Commands;
using DataTransferObject.DTOClasses.Results;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface ICategoryService 
{ 
    Task<bool> AddCategory(CategoryCommand categoryDTO);
    Task<bool> DeleteCategory(int categoryId);
    Task<List<CategoryResult>> GetCategories();
}
