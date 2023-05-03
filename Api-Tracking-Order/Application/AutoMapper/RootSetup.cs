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
    public class RootSetup : Profile
    {
        public RootSetup()
        {
            CreateMap<RootDTO, Root>()
                .ForMember(d => d.OrderID, o => o.MapFrom(r => r.OrderID))
                .ForMember(d => d.KeyNF, o => o.MapFrom(r => r.KeyNF))
                .ForMember(d => d.NumberNF, o => o.MapFrom(r => r.NumberNF))
                .ForMember(d => d.SeriesNFE, o => o.MapFrom(r => r.SeriesNFE))
                .ForMember(d => d.DateNF, o => o.MapFrom(r => r.DateNF))
                .ForMember(d => d.Date_Inclusion, o => o.MapFrom(r => r.Date_Inclusion))
                .ForMember(d => d.Addressee_name, o => o.MapFrom(s => s.Addressee_name))
                .ForMember(d => d.Addressee_identification, o => o.MapFrom(s => s.Addressee_identification))
                .ForMember(d => d.Addressee_ie, o => o.MapFrom(s => s.Addressee_ie))
                .ForMember(d => d.Addressee_address, o => o.MapFrom(s => s.Addressee_address))
                .ForMember(d => d.Addressee_number, o => o.MapFrom(s => s.Addressee_number))
                .ForMember(d => d.Addressee_neighborhood, o => o.MapFrom(s => s.Addressee_neighborhood))
                .ForMember(d => d.Addressee_county, o => o.MapFrom(s => s.Addressee_county))
                .ForMember(d => d.Addressee_cep, o => o.MapFrom(s => s.Addressee_cep))
                .ForMember(d => d.Addressee_uf, o => o.MapFrom(s => s.Addressee_uf))
                .ForMember(d => d.Additional_information, o => o.MapFrom(s => s.Additional_information))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
                .ForMember(d => d.Volume, o => o.MapFrom(s => s.Volume))
                .ForMember(d => d.Weight, o => o.MapFrom(s => s.Weight))
                .ForMember(d => d.Sender_name, o => o.MapFrom(s => s.Sender_name))
                .ForMember(d => d.Sender_identification, o => o.MapFrom(s => s.Sender_identification))
                .ForMember(d => d.Sender_ie, o => o.MapFrom(s => s.Sender_ie))
                .ForMember(d => d.Sender_address, o => o.MapFrom(s => s.Sender_address))
                .ForMember(d => d.Sender_number, o => o.MapFrom(s => s.Sender_number))
                .ForMember(d => d.Sender_neighborhood, o => o.MapFrom(s => s.Sender_neighborhood))
                .ForMember(d => d.Sender_county, o => o.MapFrom(s => s.Sender_county))
                .ForMember(d => d.Sender_cep, o => o.MapFrom(s => s.Sender_cep))
                .ForMember(d => d.Sender_uf, o => o.MapFrom(s => s.Sender_uf)).ReverseMap();
        }
    }
}
