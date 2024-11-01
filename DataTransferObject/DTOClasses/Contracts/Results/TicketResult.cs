using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Results;

public class TicketResult
{
    public Guid Id { get; set; }
    public string TicketName { get; set; }
    public int Capacity { get; set; }
    public decimal price { get; set; }
    public string CategoryName { get; set; }

}
