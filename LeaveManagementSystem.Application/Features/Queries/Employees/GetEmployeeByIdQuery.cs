using MediatR;
using LeaveManagementSystem.Application.DTOs;
using AutoMapper;
using LeaveManagementSystem.Application.Interfaces;

namespace LeaveManagementSystem.Application.Features.Queries.Employees;

public record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDTO>;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
{
    private readonly IEmployeeRepository _repo;
    private readonly IMapper _mapper;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken ct)
    {
        var employee = await _repo.GetByIdAsync(request.Id);
        return _mapper.Map<EmployeeDTO>(employee);
    }
}