using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AssignmentRepository : GenericRepository<Assignment>
    {
        public AssignmentRepository(SOPOContext context) : base(context)
        {
        }

        public async Task<List<Assignment>> GetAssignmentsByResidentAsync(int residentId)
        {
            return await dbSet.Where(a => a.ResidentId == residentId).ToListAsync();
        }

        public async Task<List<Assignment>> GetAssignmentsByEmployeeAsync(string employeeId)
        {
            return await dbSet.Where(a => a.EmployeeId == employeeId).ToListAsync();
        }
    }
}
