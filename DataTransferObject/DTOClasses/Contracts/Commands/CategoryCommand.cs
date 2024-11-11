using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts.Commands;

public class CategoryCommand
{
    [Required]
    [DataType(DataType.Text)]
    public string CategoryName { get; set; }
    public TicketCategory TicketCategory { get; set; }
    public Guid CreatedUserId { get; set; }
    public string CreatorUserName { get; set; }
}
