using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<Assignment> GetSingleAssignmentAsync(int id);
        Task<List<Assignment>> GetAssignmentsByResidentAsync(int residentId);
        Task UpdateAssignmentNotesAsync(Assignment assignmentToUpdate);
    }
}
