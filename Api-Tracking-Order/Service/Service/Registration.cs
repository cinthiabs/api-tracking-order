using Domain.Entities;
using Domain.Interface;
using Elasticsearch.Net;
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

        public async Task<Root> GetOrder(int OrderID)
        {
            var returnOrder = new Root();
            try
            {
                returnOrder = await _Repository.GetOrder(OrderID);
            }
            catch (Exception Ex)
            {
                var Erro = Ex.Message;
                //Log.Error($"Erro: {Erro}");
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
                var erro = ex.Message;
                await _Repository.LogError("userQuery - Service", erro, "API Tracking Order");
            }
            return query;
        }
    }
}
