using AutoMapper;
using FinancesServer.DTOs.Expenses;
using FinancesServer.Models.Expenses;

namespace FinancesServer.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseReadDto>();
            CreateMap<ExpenseCreateDto, Expense>();
            CreateMap<ExpenseUpdateDto, Expense>();
        }
    }
}