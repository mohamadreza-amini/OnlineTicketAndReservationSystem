using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Address
{
    public City City { get; set; }
    public Guid CityId { get; set; }
    public string Description { get; set; }
    public string PostalCode { get; set; }

}
