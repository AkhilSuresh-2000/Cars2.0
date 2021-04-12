using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars2._0.AppDbContext;
using Cars2._0.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Cars2._0.Models;

namespace Cars2._0.Controllers
{
    public class ModelController : Controller
    {
        private readonly  CarsDbContext _db;
       
        [BindProperty]
        public ModelViewModel ModelVM { get; set; }

        public ModelController(CarsDbContext db)
        {
            _db = db;
            ModelVM = new ModelViewModel()
            {
                Makes = _db.Makes.ToList(),
                Model = new Models.Model()
            };

        }
        public IActionResult Index()
        {
            //get refrence of makes using eager loading
            var model = _db.Models.Include(m => m.Make);

            return View(model);
        }

        public IActionResult Create()
        {
            return View(ModelVM);
        }
        [HttpPost,ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                
                return View (ModelVM);
            }
            _db.Models.Add(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {            
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
 
            _db.Update(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ModelVM.Model = _db.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
            if(ModelVM.Model == null)
            {
                return NotFound();
            }
            return View(ModelVM);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Model model = _db.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _db.Models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
