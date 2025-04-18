using MediatR;
using LeaveManagementSystem.Application.DTOs;
using AutoMapper;
using LeaveManagementSystem.Application.Interfaces;

namespace LeaveManagementSystem.Application.Features.Queries.Employees;

public record GetAllEmployeesQuery : IRequest<List<EmployeeDTO>>;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
{
    private readonly IEmployeeRepository _repo;
    private readonly IMapper _mapper;

    public GetAllEmployeesQueryHandler(IEmployeeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken ct)
    {
        var employees = await _repo.GetAllAsync();
        return _mapper.Map<List<EmployeeDTO>>(employees);
    }
}