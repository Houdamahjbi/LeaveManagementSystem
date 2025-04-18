using LeaveManagementSystem.Domain.Enums;
using LeaveManagementSystem.Domain;
using LeaveManagementSystem.Application.Interfaces;
using MediatR;
namespace LeaveManagementSystem.Application.Features.Commands.Employees
{
    public record CreateEmployeeCommand(
      string FullName,
      DepartmentType Department,
      DateTime JoiningDate
  ) : IRequest<int>; 

    // Handler
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IEmployeeRepository _repo;
        public CreateEmployeeCommandHandler(IEmployeeRepository repo) => _repo = repo;

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken ct)
        {
            var employee = new Employee
            {
                FullName = request.FullName,
                Department = request.Department,
                JoiningDate = request.JoiningDate
            };
            await _repo.AddAsync(employee);
            return employee.Id;
        }
    }
}