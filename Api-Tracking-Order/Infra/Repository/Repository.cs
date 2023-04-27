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

        public async Task<bool> LogError(string method, string error, string application)
        {
            var returnQuery = false;
            var date = DateTime.Now;
            var dt = date.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                error = error.Replace("'", "");
                var sqlQuery = $@"Insert into LogErrorAPI (date,method,error,application) values ('{dt}','{method}','{error}', '{application}')";
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
                var erro = ex.Message;
                await LogError("userQuery - Data", erro, "API Tracking Order");
            }
            return ret;
        }
    }
}
