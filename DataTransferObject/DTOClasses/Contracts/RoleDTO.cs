using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts
{
    public class RoleDTO : BaseDTO<Guid>
    {
        public string PersianName { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
        public int StatusOfRole { get; set; }
    }
}
