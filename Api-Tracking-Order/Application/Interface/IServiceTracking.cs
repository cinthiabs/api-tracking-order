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
        Task<int> userQuery(UserDTO login);
        Task<RootDTO> GetOrder(int OrderID);
        Task<List<ReturnTrackingDTO>> GetOrderTracking(int OrderID);
        Task<ReturnDTO> InsertOrderTracking(ReturnTrackingDTO tracking);
    }
}
