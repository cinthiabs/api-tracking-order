using Domain.Interface;
using Nest;
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
        private readonly IRepository _Repository;
        public Registration(IRepository Repository)
        {
            _Repository = Repository;
        }

        public Task<bool> LogError(string method, string error, string application)
        {
            throw new NotImplementedException();
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
                var erro = ex.Message;
                await _Repository.LogError("ConsultaUsuario - Service", erro, "API Sequoia - Brudam");
            }
            return query;
        }
    }
}
