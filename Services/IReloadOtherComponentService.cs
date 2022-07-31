namespace FinancesServer.Services
{
    public interface IReloadOtherComponentService
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
    }
}