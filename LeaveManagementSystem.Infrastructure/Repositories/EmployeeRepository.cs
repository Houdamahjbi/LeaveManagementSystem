using Microsoft.EntityFrameworkCore; 
using Infrastructure.Data;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Domain;

namespace MyApp.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    // Implémentation manquante de l'interface
    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
            .Include(e => e.Department) // Si vous avez une relation avec Department
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}