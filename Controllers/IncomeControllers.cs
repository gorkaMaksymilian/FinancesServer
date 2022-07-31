using AutoMapper;
using FinancesServer.Data;
using FinancesServer.DTOs.Earnings;
using FinancesServer.Models.Earnings;
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
            var incomeModel = await _repo.GetIncomeById(id);
            if(incomeModel == null)
            {
                return NotFound();
            }
            _repo.DeleteIncome(incomeModel);
            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetIncomeById")]
        public async Task<ActionResult<IncomeReadDto>> GetIncomeById(int id)
        {
            var incomeModel = await _repo.GetIncomeById(id);
            if (incomeModel != null)
            {
                return Ok(_mapper.Map<IncomeReadDto>(incomeModel));
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<IncomeReadDto>> CreateIncome(IncomeCreateDto incCreateDto)
        {
            var incomeModel = _mapper.Map<Income>(incCreateDto);
            await _repo.CreateIncome(incomeModel);
            await _repo.SaveChanges();

            var incReadDto = _mapper.Map<IncomeReadDto>(incomeModel);
            
            
            return CreatedAtRoute(nameof(GetIncomeById), new { Id = incReadDto.Id}, incReadDto);
        }
    }
}