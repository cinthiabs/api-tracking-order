using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            catch (Exception EX)
            {
                await LogError("GetOrder - Data", EX.ToString(), "API Tracking Order");
            }

            return returnQuery;
        }

        public async Task<ReturnTracking> GetOrderTracking(int OrderID)
        {
            var returnQuery = new ReturnTracking();
            try
            {
                var sqlQuery = $@"select ode.orderId,tra.date,ord.description,tra.statusID  
                                from ordertable ode	 
                                inner join tracking tra on ode.orderId = tra.OrderID
                                inner join StatusOrder ord on ord.StatusId=ode.StatusId
                                where tra.active = 1 and ode.orderid='{OrderID}' ";
                returnQuery = await _Connection.ExecProcedure<ReturnTracking>(sqlQuery);
            }
            catch (Exception EX)
            {
                await LogError("GetOrderTracking - Data", EX.ToString(), "API Tracking Order");
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
            catch (Exception Ex)
            {
                _ = Ex.Message;
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
