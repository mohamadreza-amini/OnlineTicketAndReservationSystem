﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities;

public class Province : BaseEntity<Guid>
{
    public string Name { get; set; }
    public ICollection<City> Cities { get; set; }
}
