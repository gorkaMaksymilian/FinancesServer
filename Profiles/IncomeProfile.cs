using AutoMapper;
using FinancesServer.DTOs.Earnings;
using FinancesServer.Models.Earnings;

namespace FinancesServer.Profiles
{
    public class IncomeProfile : Profile
    {
        public IncomeProfile()
        {
            // Source => Target
            CreateMap<Income, IncomeReadDto>();
            CreateMap<IncomeCreateDto, Income>();
            CreateMap<IncomeUpdateDto, Income>();
        }
    }
}