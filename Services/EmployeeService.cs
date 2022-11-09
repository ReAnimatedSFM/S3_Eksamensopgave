using Entities;
using Services.Interfaces;

namespace Services
{
    public class EmployeeService : RestService<Resident>, IEmployeeService
    {
        public async Task<List<Resident>> GetAllResidentsAsync()
        {
            return await DoHttpGetRequest($"Resident");
        }
    }
}