using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Data;
using StudentCRUD.Models;

namespace StudentCRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentController(ApplicationDbContext _dbContext) 
        {
           dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                dbContext.students.Add(new Data.DataModel.Student
                {
                    StudentName = model.StudentName,
                    StudentEmail = model.StudentEmail,
                    DateOfBirth = model.DateOfBirth,
                });
                dbContext.SaveChanges();
                return RedirectToAction(nameof(GetList));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            List<StudentViewModel> studentlist = new List<StudentViewModel>();
            var list = dbContext.students.ToList();
            foreach(var student in list)
            {
                studentlist.Add(new StudentViewModel
                {
                    StudentId= student.StudentId,
                    StudentName = student.StudentName,
                    StudentEmail = student.StudentEmail,
                    DateOfBirth = student.DateOfBirth,
                });
            }
            return View(studentlist);
        }
        [HttpGet]
        public IActionResult Update(int StudentId)
        {
            var student = dbContext.students.Find(StudentId);
            if(student is not null)
            {
                StudentViewModel model = new()
                {StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    StudentEmail = student.StudentEmail,
                    DateOfBirth = student.DateOfBirth,
                };
                return View(model);
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult Update(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = dbContext.students.Find(model.StudentId);
                if (student is not null)
                {
                    student.StudentName = model.StudentName;
                    student.StudentEmail = model.StudentEmail;
                    student.DateOfBirth = model.DateOfBirth;
                    dbContext.SaveChanges();
                    return RedirectToAction(nameof(GetList));
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int StudentId)
        {
            var student = dbContext.students.Find(StudentId);
            if (student is not null)
            {
                dbContext.students.Remove(student);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(GetList));
            }
            return View("Error");
        }

        

    }
}
