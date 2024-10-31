using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts;

public class CategoryDTO : BaseDTO<int>
{
    public Guid CreatorUserId { get; set; }
    public string CreatorUserName { get; set; }
    public string CategoryName { get; set; }
}
