namespace Assesment1.question2
{
    // 2. Create list of Department(DepartmentId, DepartmentName) and Employee(EmployeeId, EmployeeName,
    // DepartmentId) classes.
    //Create list of 20 Employees and list of 5 Departments.Write a function that returns list of
    //EmployeeDetails(EmployeeId, EmployeeName, DepartmentName) class by using these two lists.
    public class Question2
    {

        // use the Employee class for list 
        private static List<Employee> ListEmployee()
        {
            var list = new List<Employee>();

            Console.WriteLine("Enter Names Of Employee ");
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"Enter Name Of Employee of Id {i}  = ");
                var empName = Console.ReadLine();
                list.Add(GetEmployes(i, empName));
            }

            return list;
        }
        // intializing the property 
        private static Employee GetEmployes(int id, string name)
        {
            return new Employee()
            {
                EmployeeId = id,
                EmployeeName = name,
            };
        }



        public static void DepartmentList()
        {
            // create a department with  id and name
            var Department = new[]
            {
                new {DepartmentId =1 ,DepartmentName ="MERN"},
                new {DepartmentId =2 ,DepartmentName ="MS"},
                new {DepartmentId =3 ,DepartmentName ="MEAN"},
                new {DepartmentId =4 ,DepartmentName ="Python"},
                new {DepartmentId =5 ,DepartmentName ="AI-ML"},

            };
            var students = ListEmployee();
    
                var listing = students.Join
            (
                Department,
                x => x.EmployeeId,
                y => y.DepartmentId,

                (a, b) => new { a.EmployeeId, a.EmployeeName, b.DepartmentName }
            ).ToList();
                foreach (var item in listing)
                    Console.WriteLine(item);

            }

        




        }
    }
}
