using LeaveManagementSystem.Domain.Enums;

namespace LeaveManagementSystem.Application.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Department { get; set; }
    public string DepartmentName => Department.ToString();
    public DateTime JoiningDate { get; set; }
}