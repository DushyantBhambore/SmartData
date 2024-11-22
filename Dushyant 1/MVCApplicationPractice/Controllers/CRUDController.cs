using Microsoft.AspNetCore.Mvc;
using MVCApplicationPractice.Data;
using MVCApplicationPractice.Models;

namespace MVCApplicationPractice.Controllers
{
    public class CRUDController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CRUDController(ApplicationDbContext _dbContext)
        {
           dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CRUDViewModel model)
        {
            if(ModelState.IsValid)
            {
                dbContext.cRUDs.Add(new Data.DataModel.CRUD
                {
                    Id = model.Id,
                    Name = model.Name,
                    Age = model.Age,
                    Gender = model.Gender,
                    Number = model.Number,
                });
                dbContext.SaveChanges();
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult GetList()
        {
            List<CRUDViewModel> viewModels = new List<CRUDViewModel>();
            var list = dbContext.cRUDs.ToList();
            foreach(var model in list)
            {
                viewModels.Add(new CRUDViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    Age = model.Age,
                    Gender = model.Gender,
                    Number = model.Number,
                });
            }
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var obj = dbContext.cRUDs.Find(Id);
            if(obj is not null)
            {
                CRUDViewModel model = new()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Age = obj.Age,
                    Gender = obj.Gender,
                    Number = obj.Number,
                };
                return View(model);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult Update(CRUDViewModel model)
        {
            if(ModelState.IsValid)
            {
                var obj = dbContext.cRUDs.Find(model.Id);
                if(obj is not null)
                {
                    obj.Name = model.Name;
                    obj.Age = model.Age;
                    obj.Gender = model.Gender;
                    obj.Number = model.Number;
                    dbContext.SaveChanges();
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var obj = dbContext.cRUDs.Find(Id);
            if(obj is not null)
            {
                dbContext.cRUDs.Remove(obj);
                dbContext.SaveChanges();
            }
            return View("Error");
        }
    }
}
