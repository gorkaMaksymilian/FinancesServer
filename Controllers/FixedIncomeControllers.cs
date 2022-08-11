using AutoMapper;
using FinancesServer.Data.FixedIncomes;
using FinancesServer.DTOs.FixedIncomes;
using FinancesServer.Models.FixedIncome;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace FinancesServer.Controllers
{
    [Route("/api/fixedincome")]
    [ApiController]
    public class FixedIncomeControllers : ControllerBase
    {
        private readonly IFixedIncomeRepo _repo;
        private readonly IMapper _mapper;

        public FixedIncomeControllers(IFixedIncomeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixedIncomeReadDto>>> GetAllFixedIncomes()
        {
            var allEarnings = await _repo.GetAllFixedIncomes();

            return Ok(_mapper.Map<IEnumerable<FixedIncomeReadDto>>(allEarnings));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFixedIncome(int id)
        {
            var fixedIncomeModel = await _repo.GetFixedIncomeById(id);
            if(fixedIncomeModel == null)
            {
                return NotFound();
            }
            _repo.DeleteFixedIncome(fixedIncomeModel);
            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetFixedIncomeById")]
        public async Task<ActionResult<FixedIncomeReadDto>> GetFixedIncomeById(int id)
        {
            var fixedIncomeModel = await _repo.GetFixedIncomeById(id);
            if (fixedIncomeModel != null)
            {
                return Ok(_mapper.Map<FixedIncomeReadDto>(fixedIncomeModel));
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<FixedIncomeReadDto>> CreateFixedIncome(FixedIncomeCreateDto fIncCreateDto)
        {
            var fixedIncomeModel = _mapper.Map<FixedIncome>(fIncCreateDto);
            await _repo.CreateFixedIncome(fixedIncomeModel);
            await _repo.SaveChanges();

            var incReadDto = _mapper.Map<FixedIncomeReadDto>(fixedIncomeModel);
            
            
            return CreatedAtRoute(nameof(GetFixedIncomeById), new { Id = incReadDto.Id}, incReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIncome(int id, FixedIncomeUpdateDto fIncUpdateDto)
        {
            var fixedIncomeModel = await _repo.GetFixedIncomeById(id);
            if(fixedIncomeModel == null)
            {
                return NotFound();
            }
            _mapper.Map(fIncUpdateDto, fixedIncomeModel);

            await _repo.SaveChanges();

            return NoContent();
        }
    }
}