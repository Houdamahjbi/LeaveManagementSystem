using LeaveManagementSystem.Domain;
using LeaveManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Application.Interfaces
{
   
    public interface IAppDbContext
    {
        DbSet<Employee> Employees { get; }
        DbSet<LeaveRequest> LeaveRequests { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

