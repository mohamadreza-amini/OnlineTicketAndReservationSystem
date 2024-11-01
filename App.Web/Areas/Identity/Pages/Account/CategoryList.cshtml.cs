using DataTransferObject.DTOClasses.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;

namespace App.Web.Areas.Identity.Pages.Account
{
    [Authorize]
    public class CategoryListModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public CategoryListModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [BindProperty]
        public List<CategoryResult> CategoryResult { get; set; }

        public async Task OnGet()
        {
            CategoryResult =await _categoryService.GetCategories();

        }
    }
}
