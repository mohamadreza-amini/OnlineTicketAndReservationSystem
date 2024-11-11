using DataTransferObject.DTOClasses.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DTOClasses.Contracts.Commands
{
    public class VehicleCommand
    {
        [Required]
        public string Comapany { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Origin { get; set; }
        [Required]
        public string VehicleName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public List<CategoryResult> Categories { get; set; }
       
    }
}
