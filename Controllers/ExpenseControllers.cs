using AutoMapper;
using FinancesServer.Data;
using FinancesServer.DTOs.Expenses;
using FinancesServer.Models.Expenses;
using Microsoft.AspNetCore.Mvc;

namespace FinancesServer.Controllers
{
    [Route("/api/expense")]
    [ApiController]
    public class ExpenseControllers : ControllerBase
    {
        private readonly IExpenseRepo _repo;
        private readonly IMapper _mapper;

        public ExpenseControllers(IExpenseRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseReadDto>>> GetAllExpenses()
        {
            var allEarnings = await _repo.GetAllExpenses();

            return Ok(_mapper.Map<IEnumerable<ExpenseReadDto>>(allEarnings));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense(int id)
        {
            var expenseModel = await _repo.GetExpenseById(id);
            if(expenseModel == null)
            {
                return NotFound();
            }
            _repo.DeleteExpense(expenseModel);
            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpGet("{id}", Name = "GetExpenseById")]
        public async Task<ActionResult<ExpenseReadDto>> GetExpenseById(int id)
        {
            var expenseModel = await _repo.GetExpenseById(id);
            if (expenseModel != null)
            {
                return Ok(_mapper.Map<ExpenseReadDto>(expenseModel));
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<ExpenseReadDto>> CreateExpense(ExpenseCreateDto expCreateDto)
        {
            var expenseModel = _mapper.Map<Expense>(expCreateDto);
            await _repo.CreateExpense(expenseModel);
            await _repo.SaveChanges();

            var expReadDto = _mapper.Map<ExpenseReadDto>(expenseModel);
            
            
            return CreatedAtRoute(nameof(GetExpenseById), new { Id = expReadDto.Id}, expReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpense(int id, ExpenseUpdateDto ExpenseUpdateDto)
        {
            var expenseModel = await _repo.GetExpenseById(id);
            if(expenseModel == null)
            {
                return NotFound();
            }
            _mapper.Map(ExpenseUpdateDto, expenseModel);

            await _repo.SaveChanges();

            return NoContent();
        }
    }
}