using Microsoft.AspNetCore.Mvc;
using MVCApplicationPractice.Data;
using MVCApplicationPractice.Models;

namespace MVCApplicationPractice.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
             if(ModelState.IsValid)
            {
                dbContext.registers.Add(new Data.DataModel.Register
                {
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassowrd = model.ConfirmPassowrd,
                });
                dbContext.SaveChanges();
            }
             return View(model);
        }

        [HttpGet]
        public IActionResult Logins()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegisterViewModel model )
        {
            var obj = dbContext.registers.Where(s=>s.Email== model.Email && s.Password==model.Password && s.ConfirmPassowrd==model.ConfirmPassowrd).FirstOrDefault();
            if(obj is null)
            {
                ModelState.AddModelError("", "Invalid Credential");
                return View(model);
            }
            ViewBag.Message = "Succesfull Login";
            return View(model);
        }

    }
}
