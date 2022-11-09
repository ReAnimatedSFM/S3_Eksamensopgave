using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    /// <summary>
    /// Represents the interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        SOPOContext Context { get; }
        AssignmentRepository AssignmentRepository { get; }
        EmployeeRepository EmployeeRepository { get; }
        ResidentRepository ResidentRepository { get; }

        Task SaveAsync();
    }
}
