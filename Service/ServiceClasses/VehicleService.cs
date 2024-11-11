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

public class VehicleService : IVehicleService
{
    private readonly IBaseRepository<Vehicle,int> _vehicleRepository;

    public VehicleService(IBaseRepository<Vehicle, int> vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<bool> AddVehicle(VehicleCommand vehicleCommand)
    {
        if(string.IsNullOrWhiteSpace(vehicleCommand.Comapany)||
            string.IsNullOrWhiteSpace(vehicleCommand.Destination)||
            string.IsNullOrWhiteSpace(vehicleCommand.Origin)||
            string.IsNullOrWhiteSpace(vehicleCommand.VehicleName)||
            vehicleCommand.CategoryId == 0)
        {
            return false;
        }

        await _vehicleRepository.CreateDataAsync(vehicleCommand.Adapt<Vehicle>());
        return true;
    }
}
