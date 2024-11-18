using Microsoft.AspNetCore.Mvc;
using sales_pets.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
public class CategoryController : Controller
{
    // GET: Category/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Category/Create
    [HttpPost]
    public async Task<IActionResult> Create(Pet pet)
    {
        if (ModelState.IsValid)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://petstore.swagger.io/v2/pet");

               var jsonContent = new StringContent(JsonConvert.SerializeObject(new
                {
                    id = pet.Id,
                    category = new { id = pet.CategoryId, name = pet.CategoryName },
                    name = pet.Name,
                    photoUrls = new[] { "photoUrls" },
                    tags = new[] { new { id = pet.CategoryId, name = pet.CategoryName } },
                    status = pet.Status
                }), Encoding.UTF8, "application/json");


                request.Content = jsonContent;

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the pet.");
                }
            }
        }
        return View(pet);
    }
}