using Assesment2DotNet.Data;
using Assesment2DotNet.Interface;
using Assesment2DotNet.Model;

namespace Assesment2DotNet.Services
{
    public class EmployeeServices : IEmployee
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeServices(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public void AddEmployee(Employee model)
        {

            dbContext.employees.Add(new Model.Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salary = model.Salary,

            });
            dbContext.SaveChanges();


        }

        public void DeleteEmployee(int id)
        {
            var obj = dbContext.employees.Find(id);
            if (obj != null)
            {
                dbContext.employees.Remove(obj);
                dbContext.SaveChanges();
            }

        }

        public Employee GetEmployee(int id)
        {
            var obj = dbContext.employees.Find(id);
            if (obj is not null)
            {
                Employee model = new()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Salary = obj.Salary,
                };
                return model;
            }
            return null;
        }

        public List<Employee> GetEmployeeList()
        {
            List<Employee> model = new();
            var list = dbContext.employees.ToList();

            foreach (var obj in list)
            {
                model.Add(new Employee
                {
                  Id =obj.Id,
                  FirstName = obj.FirstName,
                  LastName = obj.LastName,
                  Salary = obj.Salary,
                });
            }
            return model;
        }

        public void UpdateEmployee(Employee model)
        {
            var obj = dbContext.employees.FirstOrDefault(a=>a.Id == model.Id);
            if (obj is not null)
            {
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Salary = model.Salary;
                dbContext.SaveChanges();
            }
        }
    }
}
