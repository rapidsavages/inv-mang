using Microsoft.AspNetCore.Mvc;
using PreeceTechnology.Models;
using Microsoft.EntityFrameworkCore;
using PreeceTechnology.Data;

namespace PreeceTechnology.Controllers
{
    public class InventoryController : Controller

    {
        private InventoryContext context { get; set; }
        public InventoryController(InventoryContext ctx)
        {
            context = ctx;
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();
            return View("Edit", new Inventory());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();
            var inventory = context.Inventory.Find(id);
            return View(inventory);
        }

        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                if (inventory.Id == 0)
                {
                    context.Inventory.Add(inventory);
                }
                else
                {
                    context.Inventory.Update(inventory);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Inventory");
            }
            else
            {
                ViewBag.Departments = context.Departments.OrderBy(d => d.DepartmentName).ToList();
                ViewBag.Action = (inventory.Id == 0) ? "Add" : "Edit";
                return View(inventory);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var inventory = context.Inventory.Find(id);
            return View(inventory);
        }

        [HttpPost]
        public IActionResult Delete(Inventory inventory)
        {
            ViewBag.Action = "Delete";
            context.Inventory.Remove(inventory);
            context.SaveChanges();
            return RedirectToAction("Index", "Inventory");
        }

        public IActionResult Index()
        {
            var inventory = context.Inventory.Include(e => e.Department).ToList();
            return View(inventory);
        }
        [HttpGet]
        public IActionResult Stock()
        {
            ViewBag.Stock = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Stock(Inventory model)
        {
            ViewBag.Stock = model.CalculateStock();
            return View(model);
        }
    }
}
