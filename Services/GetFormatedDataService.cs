using FinancesServer.Models.Dashboard;
using FinancesServer.Models.Earnings;
using FinancesServer.Models.Expenses;

namespace FinancesServer.Services
{
    public class GetFormatedDataService : IGetFormatedDataService
    {
        private readonly HttpClient _http;
        private readonly string? BaseUri = "https://localhost:7213/";



        public GetFormatedDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<MonthlyItem>> GetMonthlyEarnings(int month, int year)
        {
            var data = await _http.GetFromJsonAsync<List<Income>>($"{BaseUri}api/income");

            return data!.Where(inc => inc.Date >= new DateTime(year, month, 1) &&
                   inc.Date <= new DateTime(year, month, DateTime.DaysInMonth(year, month)))
                   .GroupBy(inc => inc.Category)
                   .Select(inc => new MonthlyItem
                   {
                        Amount = inc.Sum(item => item.Amount),
                        Category = inc.Key.ToString()
                   });
        }

        public async Task<IEnumerable<MonthlyItem>> GetMonthlyExpenses(int month, int year)
        {
            var data = await _http.GetFromJsonAsync<List<Expense>>($"{BaseUri}api/expense");

            return data!.Where(exp => exp.Date >= new DateTime(year, month, 1) &&
                   exp.Date <= new DateTime(year, month, DateTime.DaysInMonth(year, month)))
                   .GroupBy(exp => exp.Category)
                   .Select(exp => new MonthlyItem
                   {
                        Amount = exp.Sum(item => item.Amount),
                        Category = exp.Key.ToString()
                   });
        }
    }
}