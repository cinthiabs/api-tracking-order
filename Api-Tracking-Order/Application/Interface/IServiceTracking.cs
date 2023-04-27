using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IServiceTracking
    {
        public Task<int> userQuery(UserDTO login);
        public Task<RootDTO> GetOrder(int OrderID);

    }
}
