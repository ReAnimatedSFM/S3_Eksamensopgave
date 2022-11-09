using DataAccess.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UOW
{
    /// <summary>
    /// Represents the UnitOfWork class
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        #region Fields

        private SOPOContext context = new();
        private AssignmentRepository assignmentRepository;
        private EmployeeRepository employeeRepository;
        private ResidentRepository residentRepository;

        #endregion

        #region Properties

        public SOPOContext Context
        {
            get { return context; }
        }
        public AssignmentRepository AssignmentRepository
        {
            get
            {
                if (this.assignmentRepository == null)
                {
                    this.assignmentRepository = new AssignmentRepository(context);
                }
                return assignmentRepository;
            }
        }
        public EmployeeRepository EmployeeRepository
        {
            get
            {
                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new EmployeeRepository(context);
                }
                return employeeRepository;
            }
        }
        public ResidentRepository ResidentRepository
        {
            get
            {
                if (this.residentRepository == null)
                {
                    this.residentRepository = new ResidentRepository(context);
                }
                return residentRepository;
            }
        }

        #endregion

        #region Methods

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        #endregion

        #region IDisposable members

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
