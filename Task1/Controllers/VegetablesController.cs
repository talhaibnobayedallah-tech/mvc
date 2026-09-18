using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models.DAL.Database; // Resolves ApplicationDbContext
using Task1.Models.DAL.Entities; // Resolves Vegetable
namespace Task1.Controllers
{
    public class VegetablesController : Controller
    {

        public IActionResult  Index()
        {
            return View();
        }
    }
}
