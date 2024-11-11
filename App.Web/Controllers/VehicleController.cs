using DataTransferObject.DTOClasses.Contracts.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterfaces;
using Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace App.Web.Controllers;

public class VehicleController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IVehicleService _vehicleService;
    public VehicleController(ICategoryService categoryService, IVehicleService vehicleService)
    {
        _categoryService = categoryService;
        _vehicleService = vehicleService;
    }
    [HttpGet]
    public async Task<IActionResult> AddVehicle()
    {
        var vehicleCommand = new VehicleCommand();
        vehicleCommand.Categories = await _categoryService.GetByCategoryType(Shared.Enums.TicketCategory.Vehicle);
        return View(vehicleCommand);
    }

    [HttpPost]
    public async Task<IActionResult> AddVehicle(VehicleCommand vehicleCommand)
    {
        _vehicleService.AddVehicle(vehicleCommand);
        return RedirectToAction("AddVehicle");
    }




    [HttpGet]
    public IActionResult AddVehicleCategory()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddVehicleCategory([FromBody] CategoryCommand categoryCommand)
    {
        categoryCommand.TicketCategory = TicketCategory.Vehicle;
        categoryCommand.CreatedUserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        categoryCommand.CreatorUserName = HttpContext.User.Identity.Name;

        if (await _categoryService.AddCategory(categoryCommand))
        {
            return Json("Success");
        }
        return Json("Failed");
    }

    [HttpGet]
    public IActionResult AddResidenceCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddResidenceCategory([FromBody] CategoryCommand categoryCommand)
    {
        categoryCommand.TicketCategory = TicketCategory.residence;
        categoryCommand.CreatedUserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        categoryCommand.CreatorUserName = HttpContext.User.Identity.Name;

        if (await _categoryService.AddCategory(categoryCommand))
        {
            return Json("Success");
        }
        return Json("Failed");
    }
}


