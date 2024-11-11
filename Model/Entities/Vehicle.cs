using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Vehicle:BaseEntity<int>
{
    public string Comapany {  get; set; }
    public string Destination { get; set; }
    public string Origin { get; set; }
    public string VehicleName{ get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }

}
