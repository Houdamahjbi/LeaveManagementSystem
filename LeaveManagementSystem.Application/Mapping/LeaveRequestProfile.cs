using AutoMapper;
using LeaveManagementSystem.Application.DTOs;
using LeaveManagementSystem.Domain.Entities;

namespace LeaveManagementSystem.Application.Mapping
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<CreateLeaveRequestDTO, LeaveRequest>();
        }
    }
}