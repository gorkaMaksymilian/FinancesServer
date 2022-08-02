using FinancesServer.Models.Dashboard;
using FinancesServer.Models.Earnings;


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
    }
}