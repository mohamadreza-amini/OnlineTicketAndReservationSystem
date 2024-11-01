using DataTransferObject.DTOClasses.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace App.Web.Areas.Identity.Pages.Account;

public class RegisterTicketModel : PageModel
{
    private readonly ICategoryService _categoryService;
    private readonly ITicketService _ticketService;

    public RegisterTicketModel(ICategoryService categoryService, ITicketService ticketService)
    {
        _categoryService = categoryService;
        _ticketService = ticketService;
    }

    public async Task OnGet()
    {
        ticketCommand = new TicketCommand();
        ticketCommand.Categories = await _categoryService.GetCategories();
    }

    [BindProperty]
    public TicketCommand ticketCommand { get; set; }


    public async Task<IActionResult> OnPost ()
    {
        ticketCommand.CreatedUserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        ticketCommand.CreatorUserName = HttpContext.User.Identity.Name;

        await _ticketService.AddTicket(ticketCommand);

        ticketCommand.Categories = await _categoryService.GetCategories();
        return Page();
    
    }
}


