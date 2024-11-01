using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts.Commands;

public class CategoryCommand
{
    public string CategoryName { get; set; }
    public Guid CreatedUserId { get; set; }
    public string CreatorUserName { get; set; }
}
