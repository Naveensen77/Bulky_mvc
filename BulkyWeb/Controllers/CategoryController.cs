using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categorys.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categorys.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditCategory(int? Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            Category categoryfromdb = _db.Categorys.Find(Id);
            //Category categoryfromdb2 = _db.Categorys.FirstOrDefault(u=>u.Id==Id);
            //Category categoryfromdb3 = _db.Categorys.Where(t=>t.Id==Id).FirstOrDefault;
            if (categoryfromdb == null)
                return NotFound();
            return View(categoryfromdb);

        }
        [HttpPost]
        public IActionResult EditCategoryData(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categorys.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteCategory(int? Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            Category categoryfromdb = _db.Categorys.Find(Id);
            if (categoryfromdb == null)
                return NotFound();
            return View(categoryfromdb);

        }
        public IActionResult DeleteCategoryPost(int? Id)
        {
            Category? obj = _db.Categorys.Find(Id);

            if (obj == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.Categorys.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


    }

}
