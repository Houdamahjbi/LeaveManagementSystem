using MediatR;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Domain.Entities;

namespace LeaveManagementSystem.Application.Features.Commands.Employees;

// Commande
public record UpdateEmployeeCommand(
    int Id,
    string FullName,
    string Department,
    DateTime JoiningDate
) : IRequest<string>; // <-- Changé de Unit à string

// Handler
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, string>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<string> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id);

        employee.FullName = request.FullName;
        employee.Department = request.Department;
        employee.JoiningDate = request.JoiningDate;

        await _employeeRepository.UpdateAsync(employee);

        return "Employee updated successfully!"; // Message de succès
    }
}