using AutoMapper;
using LeaveManagementSystem.Domain.Entities;
using LeaveManagementSystem.Application.DTOs;
using LeaveManagementSystem.Domain;

namespace LeaveManagementSystem.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department.ToString()));
    }
}