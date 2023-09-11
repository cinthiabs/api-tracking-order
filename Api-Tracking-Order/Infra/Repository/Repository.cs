using Domain.Entities;
using Domain.Interface;

namespace Infra.Repository
{
    public class Repository : IRepository
    {
        private readonly IConnection _Connection;
        public Repository(IConnection Connection)
        {
            _Connection = Connection;
        }

        public async Task<Root> GetOrder(int OrderID)
        {
            var returnQuery = new Root();
            try
            {
                var sqlQuery = $@"select * from OrderTable where orderid='{OrderID}' ";
                returnQuery = await _Connection.ExecProcedure<Root>(sqlQuery);
            }
            catch (Exception ex)
            {
                await LogError("GetOrder - Data", ex.ToString(), "API Tracking Order");
            }

            return returnQuery;
        }
        public async Task<int> GetStatus(int statusID)
        {
            int returnQuery = 0;
            try
            {
                var sqlQuery = $@"select statusid from StatusOrder where active=1 and statusID='{statusID}' ";
                returnQuery = await _Connection.ExecSelect<int>(sqlQuery);
            }
            catch (Exception ex)
            {
                await LogError("GetStatus - Data", ex.ToString(), "API Tracking Order");
            }

            return returnQuery;
        }

        public async Task<List<ReturnTracking>> GetOrderTracking(int OrderID)
        {
            var returnQuery = new List<ReturnTracking>();
            try
            {
                var sqlQuery = $@"select ode.orderId, tra.date, ord.description, tra.statusID  
                        from ordertable ode	 
                        inner join tracking tra on ode.orderId = tra.OrderID
                        inner join StatusOrder ord on ord.StatusId = ode.StatusId
                        where tra.active = 1 and ode.orderid='{OrderID}' ";
                returnQuery = (List<ReturnTracking>)await _Connection.ExecSelectList<ReturnTracking>(sqlQuery);
            }
            catch (Exception ex)
            {
                await LogError("GetOrderTracking - Data", ex.ToString(), "API Tracking Order");
            }

            return returnQuery;
        }

        public async Task<bool> InsertOrderTracking(int orderid, DateTime date, int statusID)
        {
            var returnQuery = false;
            try
            {
                var sqlQuery = $@"insert into tracking values ('{orderid}','{statusID}','1','{date}') ";
                returnQuery = await _Connection.ExecCommand(sqlQuery);
            }
            catch (Exception ex)
            {
                await LogError("InsertOrderTracking - Data", ex.ToString(), "API Tracking Order");
            }

            return returnQuery;
        }

        public async Task<bool> LogError(string method, string error, string application)
        {
            var returnQuery = false;
            var date = DateTime.Now;
            try
            {
                error = error.Replace("'", "");
                var sqlQuery = $@"Insert into LogErrorAPI (date,method,error,application) values ('{date}','{method}','{error}', '{application}')";
                returnQuery = await _Connection.ExecCommand(sqlQuery);
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
            return returnQuery;
        }

        public async Task<bool> UpdateOrderTracing(int OrderID, int statusID)
        {
            var returnQuery = false;
            try
            {
                var sqlQuery = $@"update ordertable set statusid = {statusID}  where orderid='{OrderID}' ";
                returnQuery = await _Connection.ExecCommand(sqlQuery);
            }
            catch (Exception ex)
            {
                await LogError("UpdateOrderTracing - Data", ex.ToString(), "API Tracking Order");
            }

            return returnQuery;
        }

        public async Task<int> userQuery(string name, string password)
        {
            int ret = 0;
            try
            {
                string sqlQuery = $@"select count(0) from Authentication(NOLOCK) where [user] = '{name}' and [active] = 1 and [password] ='{password}';";
                ret = await _Connection.ExecProcedure<int>(sqlQuery);
            }
            catch (Exception ex)
            {
                await LogError("userQuery - Data", ex.ToString(), "API Tracking Order");
            }
            return ret;
        }
    }
}
