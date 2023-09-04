using Domain.Entities;
using Domain.Interface;
using Service.Interface;

namespace Service.Service
{
    public class Registration : IRegistration
    {
        private readonly IRepository _Repository;
        public Registration(IRepository Repository)
        {
            _Repository = Repository;
        }
        public async Task<Root> GetOrder(int OrderID)
        {
            var returnOrder = new Root();
            try
            {
                returnOrder = await _Repository.GetOrder(OrderID);
            }
            catch (Exception Ex)
            {
                await _Repository.LogError("GetOrder - Service", Ex.ToString(), "API Tracking Order");
            }
            return returnOrder;
        }

        public async Task<List<ReturnTracking>> GetOrderTracking(int OrderID)
        {
            var returnOrder = new List<ReturnTracking>();
            try
            {
                returnOrder = await _Repository.GetOrderTracking(OrderID);
            }
            catch (Exception Ex)
            {
                await _Repository.LogError("GetOrderTracking - Service", Ex.ToString(), "API Tracking Order");
            }
            return returnOrder;
        }

        public async Task<Return> InsertOrderTracking(int orderid, DateTime date, int statusID)
        {
            var returnOrder = new Return();
            try
            {
                bool insertTracking = await _Repository.InsertOrderTracking(orderid, date, statusID);
                if (insertTracking == true)
                {
                    bool updateTracking = await _Repository.UpdateOrderTracing(orderid, statusID);
                    if (updateTracking == true)
                    {
                        returnOrder = new Return()
                        {
                            status = 1,
                            message = @$"Order {orderid} updated!"
                        };
                    }
                    else
                    {
                        returnOrder = new Return()
                        {
                            status = 0,
                            message = @$"Order not found!"
                        };
                    }
                }
                else
                {
                    returnOrder = new Return()
                    {
                        status = 0,
                        message = @$"Order not found!"
                    };
                }

            }
            catch (Exception Ex)
            {
                await _Repository.LogError("GetOrderTracking - Service", Ex.ToString(), "API Tracking Order");
            }
            return returnOrder;
        }

        public async Task<bool> LogError(string method, string error, string application)
        {
            bool query = await _Repository.LogError(method, error, application);
            return query;
        }

        public async Task<int> userQuery(string name, string password)
        {
            int query = 0;
            try
            {
                query = await _Repository.userQuery(name, password);
            }
            catch (Exception ex)
            {
                await _Repository.LogError("userQuery - Service", ex.ToString(), "API Tracking Order");
            }
            return query;
        }
    }
}
