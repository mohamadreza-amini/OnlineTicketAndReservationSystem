using DataTransferObject.DTOClasses.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.ServiceInterfaces;

namespace App.Web.Areas.Identity.Pages.Account
{
    public class TicketListModel : PageModel
    {
        private readonly ITicketService _ticketService;

        public TicketListModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [BindProperty]
        public List<TicketResult> TicketResults { get; set; }

        public async Task<IActionResult> OnGet()
        {
            TicketResults = await _ticketService.GetTickets();

            return Page();
        }
    }
}
