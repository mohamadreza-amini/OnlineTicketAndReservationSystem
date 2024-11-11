using DataTransferObject.DTOClasses.Contracts.Commands;
using Infrastructure.RepositoryInterfaces;
using Mapster;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses;

public class ResidenceService : IResidenceService
{
    private readonly IBaseRepository<Residence,int> _residenceRepository;

    public ResidenceService(IBaseRepository<Residence, int> residenceRepository)
    {
        _residenceRepository = residenceRepository;
    }

    public async Task<bool> AddResidence(ResidenceCommand residenceCommand)
    {
        if (string.IsNullOrWhiteSpace(residenceCommand.Name) ||
            string.IsNullOrWhiteSpace(residenceCommand.Name) ||
            residenceCommand.Star > 6 || residenceCommand.Star < 0 ||
            residenceCommand.CategoryId == 0)
        {
            return false;
        }
        await _residenceRepository.CreateDataAsync(residenceCommand.Adapt<Residence>());
        return true;
    }
}
