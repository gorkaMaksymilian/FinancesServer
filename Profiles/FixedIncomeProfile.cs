using AutoMapper;
using FinancesServer.DTOs.FixedIncomes;
using FinancesServer.Models.FixedIncome;

namespace FinancesServer.Profiles
{
    public class FixedIncomeProfile : Profile
    {
        public FixedIncomeProfile()
        {
            CreateMap<FixedIncome,FixedIncomeReadDto>();
            CreateMap<FixedIncomeCreateDto, FixedIncome>();
            CreateMap<FixedIncomeUpdateDto, FixedIncome>();
        }
    }
}