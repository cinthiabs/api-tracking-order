using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRegistration
    {
        Task<int> userQuery(string name, string password);
        Task<bool> LogError(string method, string error, string application);
        Task<Root> GetOrder(int OrderID);
    }
}
