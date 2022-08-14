namespace FinancesServer.Models.Dashboard
{
    public class MonthlyItem
    {
        public decimal Amount {get;}
        public string? Category {get;}


        public MonthlyItem(decimal amount, string? category)
        {
            if (category == "BiweeklySalary")
                Amount = amount*2;
            else
                Amount = amount;


            Category = category;
        }
    }
}