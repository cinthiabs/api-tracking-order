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

        public Task<bool> LogError(string method, string error, string application)
        {
            throw new NotImplementedException();
        }

        public async Task<int> userQuery(string name, string password)
        {
            int ret = 0;
            try
            {
                string sqlQuery = $@"select count(0) from Authentication WITH(NOLOCK) where user = '{name}' and active = 1 and password ='{password}';";
                ret = await _Connection.ExecProcedure<int>(sqlQuery);
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                await LogError("ConsultaUsuario - Data", erro, "API Sequoia - Brudam");
            }
            return ret;
        }
    }
}
