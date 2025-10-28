using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Train1_October.Data;
using Train1_October.Models;

namespace Train1_October.Controllers
{
    public class ItemsController : Controller
    {
        public ItemsController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;

        public void SelectCategories(int seid)
        {
            var categories = _db.categories.ToList();
            SelectList categoriesList = new SelectList(categories, "Id", "Name",seid);
            ViewBag.Categorylist = categoriesList;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> ll = _db.items.Include(C => C.Category).ToList();
            return View(ll);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SelectCategories(0);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item i)
        {
            if (!ModelState.IsValid)
            {
                return View(i);
            }
            _db.items.Add(i);
            _db.SaveChanges();
            TempData["success"] = "Item created successfully";
            return RedirectToAction("Index");
        }
        [HttpGet("id")]
        public IActionResult Edit(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(id);
            SelectCategories(item.CategoryId);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);

        }
    
        [HttpPost("id")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]Item i)
        {
            if (!ModelState.IsValid)
            {
                return View(i);
            }
            
            _db.items.Update(i);
            _db.SaveChanges();
            TempData["success"] = "Item updated successfully";
            return RedirectToAction("Index");
        } 

        [HttpGet]
        public IActionResult Delete(int? id)
        {
           
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(id);
            SelectCategories(item.CategoryId);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteItem(int? id)
        {
            
            var item = _db.items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _db.items.Remove(item);
            _db.SaveChanges();
            TempData["success"] = "Item deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
