using Application.Dto;
using Application.Interface;
using Ardalis.Result;
using AutoMapper;
using Service.Interface;

namespace Application;

public class ApplicationTracking : IApplicationTracking
{
    private readonly IRegistration _Registration;
    private readonly IMapper _mapper;

    public ApplicationTracking(IRegistration Registration, IMapper mapper)
    {
        _Registration = Registration;
        _mapper = mapper;
    }

    public  async Task<Result<RootDto>> GetOrder(int OrderID)
    {
        var returnOrder = new RootDto();
        try
        {
            var QueryOrder = await _Registration.GetOrder(OrderID);
            returnOrder = _mapper.Map<RootDto>(QueryOrder);
        }
        catch (Exception ex)
        {
            await _Registration.LogError("GetOrder - Application", ex.ToString(), "API Tracking Order");
        }

        return returnOrder;
    }

    public async Task<List<ReturnTrackingDto>> GetOrderTracking(int OrderID)
    {
        var returnOrder = new List<ReturnTrackingDto>();
        try
        {
            var QueryOrder = await _Registration.GetOrderTracking(OrderID);
            returnOrder = _mapper.Map<List<ReturnTrackingDto>>(QueryOrder);
        }
        catch (Exception ex)
        {
            await _Registration.LogError("GetOrder - Application", ex.ToString(), "API Tracking Order");
        }

        return returnOrder;
    }

    public async Task<Result<ReturnDto>> InsertOrderTracking(ReturnTrackingDto tracking)
    {
        var returnTracking = new ReturnDto();
        try
        {
            var queryTracking = await _Registration.InsertOrderTracking(tracking.Orderid,tracking.Date,tracking.StatusID);
            returnTracking = _mapper.Map<ReturnDto>(queryTracking);

        }
        catch (Exception ex)
        {
            await _Registration.LogError("InsertOrderTracking - Application", ex.ToString(), "API Tracking Order");
        }

        return returnTracking;
    }

    public async Task<Result<int>> UserQuery(UserDto login)
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
