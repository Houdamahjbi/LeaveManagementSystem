using LeaveManagementSystem.Domain;
using LeaveManagementSystem.Domain.Entities;

namespace LeaveManagementSystem.Application.Interfaces;

public interface IEmployeeRepository
{
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
    Task<Employee> GetByIdAsync(int id);
    Task<List<Employee>> GetAllAsync();
}