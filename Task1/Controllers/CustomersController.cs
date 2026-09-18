using Microsoft.AspNetCore.Mvc;
using Task1.Models.DAL.Database;
using Task1.Models.DAL.Entities;

namespace Task1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly List<string> names = ["Ahmed", "Mohammed", "Ali", "Essam", "Yossef"];
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {
            ViewBag.customers = names;
            return View();
        }

        public IActionResult GetAll()
        {
            ViewBag.Customers = db.Customers.ToList();
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult Saving(string name , string discription, int price)
        {
		if(string.IsNullOrEmpty(discription) || string.IsNullOrEmpty(name) || !(price>0)){
			ViewBag.Error = "Please check the name or disc";
			return View("Order");
		}
	     Customer agent = new Customer(){ Name = name, OrderDiscription = discription, OrderPrice=price};
            db.Customers.Add(agent);
            db.SaveChanges(); // <-- REQUIRED to execute the INSERT statement

            return RedirectToAction("GetAll");
        }


	// Another way to order with strong type 
	public IActionResult _Order(){
		return View();
	}
	public IActionResult _Saving (Customer c){
		if(!ModelState.IsValid){
			ViewBag.Error = "Please check the name or disc";
			return View("_Order");
		}
            db.Customers.Add(c);
            db.SaveChanges(); // <-- REQUIRED to execute the INSERT statement

            return RedirectToAction("GetAll");

	}


	public IActionResult Edit(int Id){
		var cust = db.Customers.Where(c => c.Id ==Id).FirstOrDefault();
		if (cust == null){
			ViewBag.Notfound = " NOT FOUND ";
			return View();

		}
		return View(cust);
	}
	public IActionResult SaveEdit(Customer new_c){

		Customer? c = db.Customers.Where(c => c.Id == new_c.Id).FirstOrDefault();
		if ( c== null) {
			return View("Edit");
		}
		c.Name = new_c.Name;
		c.OrderDiscription = new_c.OrderDiscription;
		c.OrderPrice = new_c.OrderPrice;

		db.SaveChanges();
		return RedirectToAction("GetAll");
	}

    }
}

