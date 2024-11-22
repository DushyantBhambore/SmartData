using App.Core.Interface;
using App.Core.Model;
using MediatR;
using Mapster;
using System.Threading;
using System.Threading.Tasks;
using Domain;
namespace App.Core.Apps.Employee.Command;
public class CreateEmployeeCommand : IRequest<int>
{
    public EmployeeDto Employee { get; set; }
}
public class CreateEmployeeCommandHandller : IRequestHandler<CreateEmployeeCommand, int>
{
    private readonly IApplicationDbContext applicationDbContext;

    public CreateEmployeeCommandHandller(IApplicationDbContext _applicationDbContext)
    {
        applicationDbContext = _applicationDbContext;
    }
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var model = request.Employee;
        var employee = new Domain.Employee
        {
            EmployeeID = model.EmployeeID,
            DepartmentId = model.DepartmentId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Salary = model.Salary
        };

        //var student = model.Adapt<Domain.Employee>();

        await applicationDbContext.Set<Domain.Employee>().AddAsync(employee);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return employee.EmployeeID;

    }
}


