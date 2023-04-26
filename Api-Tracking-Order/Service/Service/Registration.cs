using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class Registration : IRegistration
    {
        public async Task<int> userQuery(string name, string password)
        {
            int query = 0;
            try
            {
                query = await _Repository.userQuery(name, password);
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                await _Repository.InsereLogErro("ConsultaUsuario - Service", erro, "API Sequoia - Brudam");
            }
            return query;
        }
    }
}
