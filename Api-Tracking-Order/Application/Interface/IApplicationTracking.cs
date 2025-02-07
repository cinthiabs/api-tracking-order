using Application.Dto;
using Ardalis.Result;

namespace Application.Interface;

public interface IApplicationTracking
{
    Task<Result<int>> UserQuery(UserDto login);
    Task<Result<RootDto>> GetOrder(int OrderID);
    Task<List<ReturnTrackingDto>> GetOrderTracking(int OrderID);
    Task<Result<ReturnDto>> InsertOrderTracking(ReturnTrackingDto tracking);
}