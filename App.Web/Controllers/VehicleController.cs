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

    public VehicleController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult AddVehicleCategory()
    {  
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddVehicleCategory([FromBody]CategoryCommand categoryCommand)
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


