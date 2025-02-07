using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;
public class ReturnSetup : Profile
{
    public ReturnSetup()
    {
        CreateMap<ReturnTrackingDto, ReturnTracking>().ReverseMap();
        CreateMap<ReturnDto, Return>().ReverseMap();
    }
}
