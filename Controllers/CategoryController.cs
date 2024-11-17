using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sales_pets.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    // public class CAtegoryController : ControllerBase
    // {
    // }

     public class CategoryController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewData["Title"] = $"{id} Category";
            // Here you would typically call the Pet API to get data about the category
            return View();
        }
    }
}
