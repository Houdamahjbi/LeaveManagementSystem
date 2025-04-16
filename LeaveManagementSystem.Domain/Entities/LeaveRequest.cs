using LeaveManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Domain.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }         // Clé étrangère
        public Employee Employee { get; set; }      // Navigation property
        public LeaveType LeaveType { get; set; }    // Type de congé
        public DateTime StartDate { get; set; }     // Date de début
        public DateTime EndDate { get; set; }       // Date de fin
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending; // Statut par défaut
        public string Reason { get; set; }          // Raison du congé
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Horodatage
    }
}
