using CrudOperation.DAL;
using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace CrudOperation.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyAppDbContext _context;

        public ProductController(MyAppDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var products= _context.Products.Include("Categories");

            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }
        [NonAction]
        private void LoadCategories()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "CategoryId","CategoryName");
                
        }
        [HttpPost]
        public IActionResult Create(Product  product)
        {

          
         
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
            
            
        }
        [HttpGet]
      public IActionResult Edit(int ?id)
        {
            if(id!=null)
            {
                NotFound();
            }
            LoadCategories();
            var product = _context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Categories");
            if (ModelState.IsValid)
            { 
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
            
           return View();
        }
        [HttpGet]
        public IActionResult Delete(int ?id)
        {
            if(id ==null)
            {
                return NotFound();
            }
            var product=_context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product model)
        {
            _context.Products.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
