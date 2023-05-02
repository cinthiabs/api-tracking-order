using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Api_Tracking_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IServiceTracking _service;

        public OrderController(IServiceTracking service)
        {
            _service = service;
        }
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<ReturnDTO>> InsertOrder(RootDTO root)
        {
            var retunOrder = new ReturnDTO();
            try
            {
                var insertOrder = _service.InsertOrder(root);
                if (insertOrder != null)
                {
                    retunOrder = new ReturnDTO()
                    {
                        message = "teste",
                        status = 1
                    };
                }
                else
                {
                    retunOrder = new ReturnDTO()
                    {
                        message = "teste",
                        status = 0
                    };
                }
            }
            catch(Exception) 
            {
                return StatusCode(500, "Internal error!");
            }

            return retunOrder;
        }
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<RootDTO>> GetOrder(int OrderID)
        {
            try
            {
                var returnOrder = await _service.GetOrder(OrderID);
                if (returnOrder == null) 
                {
                    return StatusCode(400, "Order not found!");
                }
                else
                {
                    return returnOrder;
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error!");
            }
        }
    }
}
       
