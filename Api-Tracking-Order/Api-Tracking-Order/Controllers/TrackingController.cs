﻿using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult<ReturnTrackingDTO>> GetOrderTracking(int OrderID)
        { 
            try
            {
                var returnOrder = await _service.GetOrderTracking(OrderID);
                if (returnOrder.orderid == 0)
                {
                    returnOrder = new ReturnTrackingDTO()
                    {
                        orderid = 0,
                        description = "Order not found!",
                        statusID = 0,
                        date = DateTime.Now,
                    };
                }
                else
                {
                    return returnOrder;

                }
                return returnOrder;
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error!");
            }
        }

    }
}
