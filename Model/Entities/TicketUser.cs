using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class TicketUser:BaseEntity<Guid>
{
    public int Number {  get; set; }
    public DateTime BuyDate { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid TicketId { get; set; }
    public Ticket Ticket { get; set; }
}
