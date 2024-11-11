using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View("Test");
    }



    public IActionResult Ajax([FromBody] NameRequest request)
    {

        string result = $"{request.Name} دریافت شد";
        return Json(result);

    }

}


public class NameRequest
{
    public string Name { get; set; }
}