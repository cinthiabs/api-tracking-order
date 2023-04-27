using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        //[Authorize("Bearer")]
        //[HttpPost]
        //public async Task<ActionResult<ReturnDTO>> InsertOrder(RootDTO root)
        //{

        //}
        //[Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<RootDTO>> GetOrder(int OrderID)
        {
            var returnOrder = new RootDTO();
            try
            {
                returnOrder = await _service.GetOrder(OrderID);
                if (returnOrder == null) { }
            }
            catch (Exception Ex)
            {
                //Log.Fatal($@"Erro:{Ex.Message}");
                return StatusCode(500, "Erro interno entre em contato.");
            }
           return returnOrder;
        }
    }
}
       
