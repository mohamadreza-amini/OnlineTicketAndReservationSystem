using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts
{
    public class TicketCommand 
    {
        public string TicketName { get; set; }
        public int Capacity { get; set; }
        public decimal price { get; set; }
        public int CategoryId { get; set; }
        public Guid CreatedUserId { get; set; }
        public string CreatorUserName { get; set; }

    }
}
