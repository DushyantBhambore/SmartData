using Assesment2DotNet.Model;

namespace Assesment2DotNet.Interface
{
    public interface IEmployee
    {
        List<Employee> GetEmployeeList();
        void AddEmployee(Employee model);

        Employee GetEmployee(int id);

        void UpdateEmployee(Employee model);

        void DeleteEmployee(int id);

    }
}
