using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Blob : BaseEntity<int>
    {
        public string FileAddress {  get; set; }
        public string MimeType { get; set; }
        public int FileSize { get; set; }

    }
}
