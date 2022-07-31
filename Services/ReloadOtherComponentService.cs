namespace FinancesServer.Services
{
    public class ReloadOtherComponentService : IReloadOtherComponentService
    {
        public event Action? RefreshRequested;

        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}