using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Security.Cryptography.Xml;

namespace Api_Tracking_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController:ControllerBase
    {
        private readonly IServiceTracking _service;

        public TrackingController(IServiceTracking service)
        {
            _service = service;
        }
        /// <summary>
        /// Get Order Tracking
        /// </summary>
        /// <param name="OrderID"> </param>
        /// <remarks>Inform the ID of order </remarks>
        /// <returns>Return data</returns>
        [ProducesResponseType(typeof(ReturnTrackingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReturnTrackingDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult> GetOrderTracking(int OrderID)
        { 
            try
            {                
                var returnOrder = await _service.GetOrderTracking(OrderID);
                if (returnOrder == null)
                {
                    returnOrder = new ReturnTrackingDTO()
                    {
                        orderid = 0,
                        description = "Order not found!",
                        statusID = 0,
                        date = DateTime.Now,
                    };
                    return Unauthorized(returnOrder);
                }
                else
                {
                    return Ok(returnOrder);
                }
            }
            catch (Exception)
            {
                var erro = (new ReturnDTO{ message = "Internal error!", status = 500 });
                return StatusCode(500,erro);
            }
        }

        /// <summary>
        /// Insert Order Tracking
        /// </summary>
        /// <remarks>
        /// Please provide the StatusID according to the description below: 
        /// 1 - Imported Order, 2 - Waiting, 3 - In Transit, 4- Delivered, 5 - Late, 6 - Canceled, 7 - In delivery, 8 - Mechanical Problem, 9 - Failure, 10 - Finished
        /// </remarks>
        /// <param name="tracking"> </param>
        /// <returns>Return data</returns>
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ReturnDTO), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> InsertOrderTracking(ReturnTrackingDTO tracking)
        {
            try
            {
                var returnbool = await _service.InsertOrderTracking(tracking);
                return Ok(returnbool);
            }
            catch (Exception)
            {
                var erro = (new ReturnDTO { message = "Internal error!", status = 500 });
                return StatusCode(500, erro);
            }
        }
    }
}
