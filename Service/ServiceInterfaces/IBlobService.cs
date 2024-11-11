using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IBlobService
    {
        Task<bool> Create(Blob blob);
    }
}
