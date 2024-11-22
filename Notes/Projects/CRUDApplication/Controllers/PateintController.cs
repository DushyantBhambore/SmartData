using CRUDApplication.Data;
using CRUDApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CRUDApplication.Controllers
{
    public class PateintController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PateintController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult AddPateint()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPateint(PateintViewModel model)
        {
            if (ModelState.IsValid)
            {
                dbContext.pateints.Add(new Data.DataModels.Pateint
                {
                    PateintId = model.PateintId,
                    PateintfirstName = model.PateintfirstName,
                    PateintlastName = model.PateintlastName,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                });
                dbContext.SaveChanges();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult PateintList()
        {
            List<PateintViewModel> pateintslist = new List<PateintViewModel>();
            var list = dbContext.pateints.ToList();

            foreach (var item in list)
            {
                pateintslist.Add(new PateintViewModel
                {
                    PateintId = item.PateintId,
                    PateintfirstName = item.PateintfirstName,
                    PateintlastName = item.PateintlastName,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                });
                
            }
            return View(pateintslist);
        }

        [HttpGet]
        public IActionResult UpdatePateint(int id)
        {
            var pateintid = dbContext.pateints.Find(id);
            if (pateintid is not null)
            {
                PateintViewModel model = new()
                {
                    PateintfirstName = pateintid.PateintlastName,
                    PateintlastName = pateintid.PateintlastName,
                    StartDate = pateintid.StartDate,
                    EndDate = pateintid.EndDate,
                };
                return View(model);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult UpdatePateint(PateintViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pateintid = dbContext.pateints.Find(model.PateintId);
                if (pateintid is not null) 
                {
                    pateintid.PateintfirstName = model.PateintfirstName;
                    pateintid.PateintlastName = model.PateintlastName;
                    pateintid.StartDate = model.StartDate;
                    pateintid.EndDate = model.EndDate;
                    dbContext.SaveChanges();
                    return RedirectToAction(nameof(PateintList));
                }
            }
            return View("Error");

        }

        [HttpPost]

        public IActionResult DeletePateint(int id)
        {
            var pateintid = dbContext.pateints.Find(id);
            if (pateintid is not null)
            {
                dbContext.pateints.Remove(pateintid);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(PateintList));
            }
            return View("Error");
        
        }
    }
}