using DataAccess;
using DataAccess.Interface;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ResidentRepository residentRepository;

        public ResidentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            residentRepository = unitOfWork.ResidentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetAllResidents()
        {
            return Ok(await residentRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Resident>> AddResident(Resident resident)
        {
            await residentRepository.InsertAsync(resident);
            await unitOfWork.SaveAsync();
            return Ok(await residentRepository.GetByIdAsync(resident.Id));
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<Resident>>> UpdateResident(Resident resident)
        {
            await residentRepository.UpdateAsync(resident);
            await unitOfWork.SaveAsync();
            return Ok(await residentRepository.GetByIdAsync(resident.Id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Resident>>> DeleteResident(int id)
        {
            await residentRepository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
            return Ok(await residentRepository.GetAllAsync());
        }
    }
}
