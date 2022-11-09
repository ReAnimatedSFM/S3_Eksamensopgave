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
    public class UnitOfWork : IDisposable
    {
        private SOPOContext context = new();

        public SOPOContext Context
        {
            get { return context; }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

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
