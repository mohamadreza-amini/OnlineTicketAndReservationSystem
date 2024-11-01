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

namespace Service.ServiceClasses;

public class TicketService : ITicketService
{
    private readonly IBaseRepository<Ticket, Guid> _ticketRepository;
    private readonly UserManager<User> _userManager;
    private readonly IBaseRepository<Category, int> _categoryRepository;

    public TicketService(IBaseRepository<Ticket, Guid> ticketRepository, UserManager<User> userManager, IBaseRepository<Category, int> categoryRepository)
    {
        _ticketRepository = ticketRepository;
        _userManager = userManager;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> AddTicket(TicketCommand ticketCommand)
    {
        if (string.IsNullOrWhiteSpace(ticketCommand.TicketName) ||
             ticketCommand.Capacity < 0 ||
             ticketCommand.price < 0 ||
             !await _categoryRepository.Exists(x => x.Id == ticketCommand.CategoryId))
        {
            return false;
        }

        var ticket = ticketCommand.Adapt<Ticket>();
        ticket.UpdatedUserId = ticket.CreatedUserId;
        await _ticketRepository.CreateDataAsync(ticket);
        return true;
    }

    public async Task<bool> DeleteTicket(Guid ticketId)
    {
        return await _ticketRepository.DeleteDataAsync(ticketId);

    }

    public async Task<List<TicketResult>> GetTickets()
    {
        var tickets = await (await _ticketRepository.GetAllAsync()).Include(x => x.Category).ToListAsync();
        return tickets.Adapt<List<TicketResult>>();

    }

}
