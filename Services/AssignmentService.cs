using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AssignmentService : RestService<Assignment>, IAssignmentService
    {
        public async Task<Assignment> GetSingleAssignmentAsync(int id)
        {
            return await DoHttpGetSingleRequest($"Assignments/{id}/Assignment");
        }

        public async Task<List<Assignment>> GetAssignmentsByResidentAsync(int residentId)
        {
            return await DoHttpGetRequest($"Assignments/{residentId}");
        }

        public async Task UpdateAssignmentNotesAsync(Assignment assignmentToUpdate)
        {
            await DoHttpPutRequest($"Assignments/Updated", assignmentToUpdate);
        }
    }
}
