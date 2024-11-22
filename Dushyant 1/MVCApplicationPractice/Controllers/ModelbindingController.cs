using Microsoft.AspNetCore.Mvc;
using MVCApplicationPractice.Models;

namespace MVCApplicationPractice.Controllers
{
    public class ModelbindingController : Controller
    {
        [HttpGet]
        public IActionResult MyList()
        {
            List<StudentViewModel> viewModels = new()
            {
                new StudentViewModel
                {
                    StuId = 1,
                    FirstName="",
                    LastName="",
                    Email ="",
                },
                new StudentViewModel
                {
                    StuId=3,
                    FirstName ="",
                    LastName="",
                    Email ="",
                }
            };
            return View(viewModels);
        }

        [HttpPost]
        public IActionResult MyList(List<StudentViewModel> student)
        {
            if(ModelState.IsValid)
            {

            }
            return View(student);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            List<StudentViewModel> student = new List<StudentViewModel>()
            {
                new StudentViewModel
                {
                    StuId = 1,
                    FirstName= "Aakash",
                    LastName ="",
                    Email = ""

                },
                new StudentViewModel
                {
                    StuId = 2,
                    FirstName = "",
                    LastName = "Meshram",
                    Email = "RM12@gamil"
                },
                new StudentViewModel
                {
                    StuId = 2,
                    FirstName = "",
                    LastName = "Bhambore",
                    Email = ""
                }

            };
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetList(List<StudentViewModel> model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult GetData()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult GetData(GetDataViewModel model)
        {
            // server side view 
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            StudentViewModel model = new()
            {
                StuId = 1,
                FirstName = "Dushyant",
                LastName = "Bhambore",
                Email = "Dushy@gmail.com",
            };

            return View(model);
        }

        public IActionResult studentList()
        {
            List<StudentViewModel> students = new List<StudentViewModel>()
            {
                new StudentViewModel
                {
                    StuId = 1,
                    FirstName= "Aakash",
                    LastName ="Manekar",
                    Email = "Ak@1234"

                },
                new StudentViewModel
                {
                    StuId = 2,
                    FirstName = "Rihant",
                    LastName = "Meshram",
                    Email = "RM12@gamil"
                },
                new StudentViewModel
                {
                    StuId = 3,
                    FirstName = "Dushyant",
                    LastName = "Bhambore",
                    Email = "Dushy@123gmail.com"
                }
            };
            return View(students);
        }
    }
}
