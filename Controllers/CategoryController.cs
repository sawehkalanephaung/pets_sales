using Microsoft.AspNetCore.Mvc;
using sales_pets.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace sales_pets.Controllers
{
    public class CategoryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // Update
        public IActionResult Update()
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
        } // END CREATE

        // UPDATE:
        // GET: Category/Update/5
        public async Task<IActionResult> Update(int id)
        {
            Pet? pet = null;
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://petstore.swagger.io/v2/pet/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    pet = JsonConvert.DeserializeObject<Pet>(jsonString);
                }
                else
                {
                    // Handle error response
                    return NotFound();
                }
            }
            return View(pet);
        }


        // POST: Category/Update/5
        [HttpPost]
        public async Task<IActionResult> Update(Pet pet, string photoUrls, string tags)
        {
            if (ModelState.IsValid)
            {
                pet.PhotoUrls = photoUrls.Split(',').Select(url => url.Trim()).ToList();
                pet.Tags = tags.Split(',').Select(tag => new PetTag { Name = tag.Trim() }).ToList();

                using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Put, "https://petstore.swagger.io/v2/pet");

                    var jsonContent = new StringContent(JsonConvert.SerializeObject(new
                    {
                        id = pet.Id,
                        name = pet.Name,
                        photoUrls = pet.PhotoUrls,
                        tags = pet.Tags.Select(t => new { name = t.Name }),
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
                        ModelState.AddModelError(string.Empty, "An error occurred while updating the pet.");
                    }
                }
            }
            return View(pet);
        } // end

        // delete 
        [HttpDelete("Category/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"https://petstore.swagger.io/v2/pet/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to delete the pet.");
                }
            }
        }


    }
}}
public class Pet
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<string> PhotoUrls { get; set; } = new List<string>();
    public List<PetTag> Tags { get; set; } = new List<PetTag>();
    public string Status { get; set; } = string.Empty;
}

public class PetTag
{
    public string Name { get; set; } = string.Empty;
}