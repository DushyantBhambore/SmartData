using CRUDApplication.Data;
using CRUDApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApplication.Controllers
{
    [AllowAnonymous]
    public class ProviderController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ProviderController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public  IActionResult AddProvider()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProvider(ProviderViewModel model)
        {
            if (ModelState.IsValid)
            {
                dbContext.providers.Add(new Data.DataModels.Provider
                {
                    
                    ProviderId = model.ProviderId,
                    DoctorName = model.DoctorName,
                    Treatment = model.Treatment,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                });
                dbContext.SaveChanges();
                return RedirectToAction(nameof(ProviderList));
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult FinalResult()
        {
            var data = (from x in dbContext.providers
                        join y in dbContext.pateints
                        on x.ProviderId equals y.PateintId
                        select new { x.DoctorName, x.Treatment, y.PateintfirstName, y.PateintlastName }).ToList();
            return View(data);
        }

        [HttpGet]

        public IActionResult ProviderList()
        {
            List<ProviderViewModel> providerlist = new List<ProviderViewModel>();
            var list = dbContext.providers.ToList();
            foreach(var item in list)
            {
                providerlist.Add(new ProviderViewModel
                {
                    ProviderId = item.ProviderId,
                    DoctorName = item.DoctorName,
                    Treatment = item.Treatment,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                });
            }
            return View(providerlist);
        }

        [HttpGet]
        public IActionResult UpdateProvider(int id)
        {
            var find_id = dbContext.providers.Find(id);

            if (find_id is not null)
            {
                ProviderViewModel model = new()
                {
                    ProviderId = find_id.ProviderId,
                    DoctorName = find_id.DoctorName,
                    Treatment = find_id.Treatment,
                    StartDate = find_id.StartDate,
                    EndDate = find_id.EndDate,

                };
                
                return View(model);
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult UpdateProvider(ProviderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var findid = dbContext.providers.Find(model.ProviderId);
                if(findid is not null)
                {
                    findid.DoctorName = model.DoctorName;
                    findid.Treatment = model.Treatment;
                    findid.StartDate = model.StartDate;
                    findid.EndDate = model.EndDate;
                    dbContext.SaveChanges();
                    return RedirectToAction(nameof(ProviderList));
                }
            }
            return View("Error");
        }
        [HttpPost]
        public IActionResult DeleteProvider(int id)
        {
            var findid = dbContext.providers.Find(id);
            if(findid is not null)
            {
                dbContext.providers.Remove(findid);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(ProviderList));
            }
            return View("Error");
        }

    }
}
