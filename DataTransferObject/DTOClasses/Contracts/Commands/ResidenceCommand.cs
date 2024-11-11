using DataTransferObject.DTOClasses.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts.Commands
{
    public class ResidenceCommand
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,6)]
        public byte Star { get; set; }
        [Required]
        public int CategoryId { get; set; }
      
        public List<CategoryResult> Categories { get; set; }
    }
}
