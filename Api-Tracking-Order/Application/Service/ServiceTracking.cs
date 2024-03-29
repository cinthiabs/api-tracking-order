﻿using Application.DTO;
using Application.Interface;
using AutoMapper;
using Service.Interface;

namespace Application.Service
{
    public class ServiceTracking : IServiceTracking
    {
        private readonly IRegistration _Registration;
        private readonly IMapper _mapper;

        public ServiceTracking(IRegistration Registration, IMapper mapper)
        {
            _Registration = Registration;
            _mapper = mapper;
        }

        public  async Task<RootDTO> GetOrder(int OrderID)
        {
            var returnOrder = new RootDTO();
            try
            {
                var QueryOrder = await _Registration.GetOrder(OrderID);
                returnOrder = _mapper.Map<RootDTO>(QueryOrder);
            }
            catch (Exception ex)
            {
                await _Registration.LogError("GetOrder - Application", ex.ToString(), "API Tracking Order");
            }

            return returnOrder;
        }

        public async Task<List<ReturnTrackingDTO>> GetOrderTracking(int OrderID)
        {
            var returnOrder = new List<ReturnTrackingDTO>();
            try
            {
                var QueryOrder = await _Registration.GetOrderTracking(OrderID);
                returnOrder = _mapper.Map<List<ReturnTrackingDTO>>(QueryOrder);
            }
            catch (Exception ex)
            {
                await _Registration.LogError("GetOrder - Application", ex.ToString(), "API Tracking Order");
            }

            return returnOrder;
        }

        public async Task<ReturnDTO> InsertOrderTracking(ReturnTrackingDTO tracking)
        {
            var returnTracking = new ReturnDTO();
            try
            {
                var queryTracking = await _Registration.InsertOrderTracking(tracking.Orderid,tracking.Date,tracking.StatusID);
                returnTracking = _mapper.Map<ReturnDTO>(queryTracking);

            }
            catch (Exception ex)
            {
                await _Registration.LogError("InsertOrderTracking - Application", ex.ToString(), "API Tracking Order");
            }

            return returnTracking;
        }

        public async Task<int> userQuery(UserDTO login)
        {
            int query = 0;
            try
            {
                query = await _Registration.userQuery(login.User, login.Password);
            }
            catch (Exception ex)
            {
                await _Registration.LogError("userQuery - Application", ex.ToString(), "API Tracking Order");
            }
            return query;
        }
    }
}
