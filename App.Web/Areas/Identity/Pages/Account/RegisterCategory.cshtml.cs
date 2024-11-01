using DataTransferObject.DTOClasses.Contracts.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entities;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web.Areas.Identity.Pages.Account
{
    [Authorize]
    public class RegisterCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public RegisterCategoryModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        public void OnGet()
        {
        
        }

        [BindProperty]
        public CategoryCommand categoryCommand { get; set; }
        public async Task<IActionResult> OnPost() 
        {
            categoryCommand.CreatedUserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            categoryCommand.CreatorUserName = HttpContext.User.Identity.Name;

            await _categoryService.AddCategory(categoryCommand);
            
            return RedirectToPage("CategoryList");
        }

    }
}
