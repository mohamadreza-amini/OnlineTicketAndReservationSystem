using DataTransferObject.DTOClasses.Contracts.Commands;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface IResidenceService
{
    Task<bool> AddResidence(ResidenceCommand residenceCommand);
}
