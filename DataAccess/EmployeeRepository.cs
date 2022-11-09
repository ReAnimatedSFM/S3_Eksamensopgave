using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Represents the EmployeeRepository class.
    /// </summary>
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(SOPOContext context) : base(context)
        {
        }

    }
}
