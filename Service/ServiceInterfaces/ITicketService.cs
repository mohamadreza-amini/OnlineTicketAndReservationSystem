using DataTransferObject;
using DataTransferObject.DTOClasses.Contracts;
using DataTransferObject.DTOClasses.Results;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface ITicketService
{
    Task<bool> AddTicket(TicketCommand ticket);
    Task<bool> DeleteTicket(Guid ticketId);
    Task<List<TicketResult>> GetTickets();
}
