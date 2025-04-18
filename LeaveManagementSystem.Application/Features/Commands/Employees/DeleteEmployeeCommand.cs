
using LeaveManagementSystem.Application.Interfaces;
using MediatR;

namespace LeaveManagementSystem.Application.Features.Commands.Employees;

public record DeleteEmployeeCommand(int Id) : IRequest<string>; // <-- Retourne string

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, string>
{
    private readonly IEmployeeRepository _repo;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken ct)
    {
        var employee = await _repo.GetByIdAsync(request.Id);
        await _repo.DeleteAsync(employee);
        return "Employee Deleted successfully!"; // Message de succès
    }
}