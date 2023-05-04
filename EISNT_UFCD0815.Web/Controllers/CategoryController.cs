using EISNT_UFCD0815.DataAccess.Data;
using EISNT_UFCD0815.Models;
using Microsoft.AspNetCore.Mvc;

namespace EISNT_UFCD0815.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        //GET
        public IActionResult Edit(int? catId)
        {
            if (catId == null || catId == 0)
                return NotFound();

            //Category? category = _db.Categories.Find(catId);
            Category? category = _db.Categories.FirstOrDefault(_ => _.Id == catId);
            //Category? category = _db.Categories.Where(_ => _.Id == catId).FirstOrDefault();

            if (category == null)
                return NotFound();

            return View(category);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        //GET
        public IActionResult Delete(int? catId)
        {
            if (catId == null || catId == 0)
                return NotFound();

            Category? category = _db.Categories.FirstOrDefault(_ => _.Id == catId);

            if (category == null)
                return NotFound();

            return View(category);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? catId)
        {
            Category? obj = _db.Categories.Find(catId);
            if (obj == null)
                return NotFound();

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}