using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api_Tracking_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        private readonly IApplicationTracking _service;

        public TrackingController(IApplicationTracking service)
        {
            _service = service;
        }
        /// <summary>
        /// Get Order Tracking
        /// </summary>
        /// <param name="OrderID"> </param>
        /// <remarks>Inform the ID of order </remarks>
        /// <returns>Return data</returns>
        [ProducesResponseType(typeof(ReturnTrackingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReturnTrackingDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ReturnDto), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<List<ReturnTrackingDto>>> GetOrderTracking(int OrderID)
        { 
            try
            {
                var returnOrder = await _service.GetOrderTracking(OrderID);
                if (returnOrder == null || returnOrder.Count == 0) 
                {
                    returnOrder = new List<ReturnTrackingDto>
                    {
                        new ReturnTrackingDto
                        {
                            Orderid = 0,
                            Description = "Order not found!",
                            StatusID = 0,
                            Date = DateTime.Now,
                        }
                    };
                        return StatusCode(401, returnOrder);
                }
                else
                {
                    return Ok(returnOrder);
                }
            }
            catch (Exception)
            {
                var erro = new ReturnDto { Message = "Internal error!", Status = 500 };
                return StatusCode(500, erro);
            }
        }

        /// <summary>
        /// Insert Order Tracking
        /// </summary>
        /// <remarks>
        /// Please provide the StatusID according to the description below: 
        /// 1 - Imported Order, 2 - Waiting, 3 - In Transit, 4- Delivered, 5 - Late, 6 - Canceled, 7 - In delivery, 8 - Mechanical Problem, 9 - Failure, 10 - Finished
        /// </remarks>
        /// <returns>Return data</returns>
        [ProducesResponseType(typeof(ReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReturnDto), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> InsertOrderTracking(ReturnTrackingDto tracking)
        {

             var returnbool = await _service.InsertOrderTracking(tracking);
             return Ok(returnbool);
            
        }
    }
}
