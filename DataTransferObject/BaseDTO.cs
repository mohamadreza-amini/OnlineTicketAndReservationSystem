using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BaseDTO<KeyTypeId>
    {
        public KeyTypeId Id { get; set; }
    }
}
