using DataAccess;
using DataAccess.Interface;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AssignmentRepository assignmentRepository;

        public AssignmentsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            assignmentRepository = unitOfWork.AssignmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAllAssignmentsAsync()
        {
            return Ok(await assignmentRepository.GetAllAsync());
        }

        [HttpGet("{id}/Assignment")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAllAssignmentsAsync(int id)
        {
            return Ok(await assignmentRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Assignment>> AddAssignment(Assignment assignment)
        {
            await assignmentRepository.InsertAsync(assignment);
            await unitOfWork.SaveAsync();
            return Ok(await assignmentRepository.GetByIdAsync(assignment.Id));
        }

        [HttpPut("Updated")]
        public async Task<IActionResult> UpdateAssignment(Assignment assignment)
        {
            await assignmentRepository.UpdateAsync(assignment);
            await unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> DeleteAssignment(int id)
        {
            await assignmentRepository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
            return Ok(await assignmentRepository.GetAllAsync());
        }

        [HttpGet("{residentId}")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAllAssignmentsByResidentAsync(int residentId)
        {
            return Ok(await unitOfWork.AssignmentRepository.GetAssignmentsByResidentAsync(residentId));
        }

        [HttpGet("{employeeId}/Assignments")]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAllAssignmentsByEmployeeAsync(string employeeId)
        {
            return Ok(await unitOfWork.AssignmentRepository.GetAssignmentsByEmployeeAsync(employeeId));
        }
    }
}
