using AutoMapper;
using FinancesServer.DTOs.FixedCosts;
using FinancesServer.Models.FixedCosts;

namespace FinancesServer.Profiles
{
    public class FixedCostProfile : Profile
    {
        public FixedCostProfile()
        {
            CreateMap<FixedCost, FixedCostReadDto>();
            CreateMap<FixedCostCreateDto, FixedCost>();
            CreateMap<FixedCostUpdateDto, FixedCost>();
        }
    }
}