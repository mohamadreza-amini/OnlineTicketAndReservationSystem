using DataTransferObject.DTOClasses.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts.Commands
{
    public class TicketCommand
    {
        [Required]
        [DataType(DataType.Text)]
        public string TicketName { get; set; }
        [Required]
        [Range(0,1000000)]
        public int Capacity { get; set; }

        [Required]
        [Range(0, 100000000000)]
        public decimal price { get; set; }
        public int CategoryId { get; set; }

        public Guid CreatedUserId { get; set; }
        public string CreatorUserName { get; set; }

        public List<CategoryResult> Categories { get; set; }

    }
}
