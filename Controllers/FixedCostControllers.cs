using AutoMapper;
using FinancesServer.Data.FixedCosts;
using FinancesServer.DTOs.FixedCosts;
using FinancesServer.Models.FixedCosts;
using Microsoft.AspNetCore.Mvc;

namespace FinancesServer.Controllers
{
    [Route("/api/fixedcost")]
    [ApiController]
    public class FixedCostControllers : ControllerBase
    {
        private readonly IFixedCostRepo _repo;
        private readonly IMapper _mapper;

        public FixedCostControllers(IFixedCostRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixedCostReadDto>>> GetAllFixedCosts()
        {
            var allEarnings = await _repo.GetAllCosts();

            return Ok(_mapper.Map<IEnumerable<FixedCostReadDto>>(allEarnings));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFixedCost(int id)
        {
            var fixedCostModel = await _repo.GetFixedCostById(id);
            if(fixedCostModel == null)
            {
                return NotFound();
            }
            _repo.DeleteFixedCost(fixedCostModel);
            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetFixedCostById")]
        public async Task<ActionResult<FixedCostReadDto>> GetFixedCostById(int id)
        {
            var fixedCostModel = await _repo.GetFixedCostById(id);
            if (fixedCostModel != null)
            {
                return Ok(_mapper.Map<FixedCostReadDto>(fixedCostModel));
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<FixedCostReadDto>> CreateFixedCost(FixedCostCreateDto fCostCreateDto)
        {
            var fixedCostModel = _mapper.Map<FixedCost>(fCostCreateDto);
            await _repo.CreateFixedCost(fixedCostModel);
            await _repo.SaveChanges();

            var incReadDto = _mapper.Map<FixedCostReadDto>(fixedCostModel);
            
            
            return CreatedAtRoute(nameof(GetFixedCostById), new { Id = incReadDto.Id}, incReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCost(int id, FixedCostUpdateDto fCostUpdateDto)
        {
            var fixedCostModel = await _repo.GetFixedCostById(id);
            if(fixedCostModel == null)
            {
                return NotFound();
            }
            _mapper.Map(fCostUpdateDto, fixedCostModel);

            await _repo.SaveChanges();

            return NoContent();
        }
    }
}