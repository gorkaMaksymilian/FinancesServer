using AutoMapper;
using FinancesServer.Data;
using FinancesServer.DTOs.Earnings;
using Microsoft.AspNetCore.Mvc;

namespace FinancesServer.Controllers
{
    [Route("/api/income")]
    [ApiController]
    public class IncomeControllers : ControllerBase
    {
        private readonly IIncomeRepo _repo;
        private readonly IMapper _mapper;

        public IncomeControllers(IIncomeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeReadDto>>> GetAllEarnings()
        {
            var allEarnings = await _repo.GetAllEarnings();

            return Ok(_mapper.Map<IEnumerable<IncomeReadDto>>(allEarnings));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIncome(int id)
        {
            var incomeModleFromRepo = await _repo.GetIncomeById(id);
            if(incomeModleFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteIncome(incomeModleFromRepo);
            await _repo.SaveChanges();

            return NoContent();
        }
    }
}