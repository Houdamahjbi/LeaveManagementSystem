namespace LeaveManagementSystem.Application.DTOs;

public record UpdateEmployeeDTO(
    string FullName,
    string Department,
    DateTime JoiningDate
);