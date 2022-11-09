using DataAccess;
using DataAccess.Interface;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly EmployeeRepository employeeRepository;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            employeeRepository = unitOfWork.EmployeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            return Ok(await unitOfWork.EmployeeRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            await employeeRepository.InsertAsync(employee);
            await unitOfWork.SaveAsync();
            return Ok(await employeeRepository.GetByIdAsync(employee.Id));
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Employee>>> UpdateEmployee(Employee employee)
        {
            await employeeRepository.UpdateAsync(employee);
            await unitOfWork.SaveAsync();
            return Ok(await employeeRepository.GetByIdAsync(employee.Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> DeleteEmployee(string id)
        {
            await employeeRepository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
            return Ok(await employeeRepository.GetAllAsync());
        }
    }
}
