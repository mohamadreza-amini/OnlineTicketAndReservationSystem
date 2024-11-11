using DataTransferObject.DTOClasses.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;

namespace App.Web.Areas.Identity.Pages.Account
{
    public class AddResidenceModel : PageModel
    {
        private readonly IResidenceService _residenceService;
        private readonly ICategoryService _categoryService;

        public AddResidenceModel(IResidenceService residenceService, ICategoryService categoryService)
        {
            _residenceService = residenceService;
            _categoryService = categoryService;
        }

        public async Task OnGet()
        {
            residenceCommand = new ResidenceCommand();
            residenceCommand.Categories =await _categoryService.GetByCategoryType(Shared.Enums.TicketCategory.residence);
        }

        [BindProperty]
        public ResidenceCommand residenceCommand { get; set; }
        public async Task OnPost() {

           await _residenceService.AddResidence(residenceCommand);
            residenceCommand = new ResidenceCommand();
            residenceCommand.Categories = await _categoryService.GetByCategoryType(Shared.Enums.TicketCategory.residence);
        }
    }
}
