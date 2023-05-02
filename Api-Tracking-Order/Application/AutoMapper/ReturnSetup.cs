using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class ReturnSetup : Profile
    {
        public ReturnSetup()
        {
            CreateMap<ReturnTrackingDTO, ReturnTracking>().ReverseMap();
        }
    }
}
