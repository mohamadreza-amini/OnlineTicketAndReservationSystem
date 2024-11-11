using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Residence : BaseEntity<int>
{
    public string Address { get; set; }
    public string Name { get; set; }
    public byte Star {  get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }

}
