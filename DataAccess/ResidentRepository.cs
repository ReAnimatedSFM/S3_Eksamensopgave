using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ResidentRepository : GenericRepository<Resident>
    {
        public ResidentRepository(SOPOContext context) : base(context)
        {
        }

    }
}
