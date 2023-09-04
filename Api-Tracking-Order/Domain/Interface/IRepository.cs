using Domain.Entities;


namespace Domain.Interface
{
    public interface IRepository
    {
        Task<int> userQuery(string name, string password);
        Task<bool> LogError(string method, string error, string application);
        Task<Root> GetOrder(int OrderID);
        Task<List<ReturnTracking>> GetOrderTracking(int OrderID);
        Task<bool> InsertOrderTracking(int orderid, DateTime date, int statusID);
        Task<bool> UpdateOrderTracing(int OrderID, int statusID);

    }
}
