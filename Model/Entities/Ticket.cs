using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Ticket : BaseEntity<Guid>
{
    public string TicketName { get; set; }
    public int Capacity { get; set; }
    public decimal price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int ResidenceId {  get; set; }
    public Residence Residence { get; set; }
    public ICollection<TicketUser> TicketUsers { get; set; }

}
