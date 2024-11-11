using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts.Commands
{
    public class BlobCommand
    {
        public string FileAddress { get; set; }
        public string MimeType { get; set; }
        public int FileSize { get; set; }
    }
}
