using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class City : BaseEntity<Guid>
{
    public string Name { get; set; }
    public Province Province { get; set; }
    public Guid ProvinceId { get; set; }
}
