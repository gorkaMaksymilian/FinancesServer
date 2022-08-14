using FinancesServer.Models.Dashboard;
using FinancesServer.Models.Earnings;
using FinancesServer.Models.Expenses;
using FinancesServer.Models.FixedCosts;
using FinancesServer.Models.FixedIncomes;

namespace FinancesServer.Services
{
    public class GetFormatedDataService : IGetFormatedDataService
    {
        private readonly HttpClient _http;
        private readonly string? _host = "https://localhost:7213/";



        public GetFormatedDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<MonthlyItem>> GetFixedCosts(int month)
        {
            List<FixedCost>? data = await _http.GetFromJsonAsync<List<FixedCost>>($"{_host}api/fixedcost");
            
            if (data is not null) 
            {
                if (month % 2 == 0) 
                {
                    return data.Where(fExp => (fExp.Category == FixedCostCategoryEnum.ElectricityBill && ((int)fExp.MonthOfFirstPayment)%2 == 0) ||
                                              (fExp.Category != FixedCostCategoryEnum.ElectricityBill))
                               .GroupBy(fExp => fExp.Category)
                               .Select(fExp => new MonthlyItem(fExp.Sum(item => item.Amount), fExp.Key.ToString()));
                }                           
                else 
                {
                    return data.Where(fExp => (fExp.Category == FixedCostCategoryEnum.ElectricityBill && ((int)fExp.MonthOfFirstPayment)%2 == 1) ||
                                              (fExp.Category != FixedCostCategoryEnum.ElectricityBill))
                               .GroupBy(fExp => fExp.Category)
                               .Select(fExp => new MonthlyItem(fExp.Sum(item => item.Amount), fExp.Key.ToString()));
                }
            }
            else
                throw new NullReferenceException();  
        }

        public async Task<IEnumerable<MonthlyItem>> GetFixedIncomes(int month)
        {
            var data = await _http.GetFromJsonAsync<List<FixedIncome>>($"{_host}api/fixedincome");

            return data!.GroupBy(fInc => fInc.Category)
                        .Select(fInc => new MonthlyItem(fInc.Sum(item => item.Amount), fInc.Key.ToString()));

            
        }

        public async Task<IEnumerable<MonthlyItem>> GetMonthlyEarnings(int month, int year)
        {
            var data = await _http.GetFromJsonAsync<List<Income>>($"{_host}api/income");

            return data!.Where(inc => inc.Date >= new DateTime(year, month, 1) &&
                               inc.Date <= new DateTime(year, month, DateTime.DaysInMonth(year, month)))
                        .GroupBy(inc => inc.Category)
                        .Select(inc => new MonthlyItem(inc.Sum(item => item.Amount), inc.Key.ToString()));
        }

        public async Task<IEnumerable<MonthlyItem>> GetMonthlyExpenses(int month, int year)
        {
            var data = await _http.GetFromJsonAsync<List<Expense>>($"{_host}api/expense");

            return data!.Where(exp => exp.Date >= new DateTime(year, month, 1) &&
                               exp.Date <= new DateTime(year, month, DateTime.DaysInMonth(year, month)))
                        .GroupBy(exp => exp.Category)
                        .Select(exp => new MonthlyItem(exp.Sum(item => item.Amount), exp.Key.ToString()));
        }
    }
}