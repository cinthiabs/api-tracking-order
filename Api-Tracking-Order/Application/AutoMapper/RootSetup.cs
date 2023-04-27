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
                .ForMember(d => d.OrderID, o => o.MapFrom(s => s.OrderID))
                .ForMember(d => d.KeyNF, o => o.MapFrom(s => s.KeyNF))
                .ForMember(d => d.NumberNF, o => o.MapFrom(s => s.NumberNF))
                .ForMember(d => d.SeriesNFE, o => o.MapFrom(s => s.SeriesNF))
                .ForMember(d => d.TpNF, o => o.MapFrom(s => s.TpNF))
                .ForMember(d => d.DateNF, o => o.MapFrom(s => s.DateNF))
                .ForMember(d => d.Date_Inclusion, o => o.MapFrom(s => s.Date_Inclusion))
                .ForMember(d => d.StatusId, o => o.MapFrom(s => s.Status));


            CreateMap<Root, RootDTO>()
                .ForMember(d => d.OrderID, o => o.MapFrom(s => s.OrderID))
                .ForMember(d => d.KeyNF, o => o.MapFrom(s => s.KeyNF))
                .ForMember(d => d.NumberNF, o => o.MapFrom(s => s.NumberNF))
                .ForMember(d => d.SeriesNF, o => o.MapFrom(s => s.SeriesNFE))
                .ForMember(d => d.TpNF, o => o.MapFrom(s => s.TpNF))
                .ForMember(d => d.DateNF, o => o.MapFrom(s => s.DateNF))
                .ForMember(d => d.Date_Inclusion, o => o.MapFrom(s => s.Date_Inclusion))
                .ForMember(d => d.Status, o => o.MapFrom(s => s.StatusId));

            CreateMap<SenderDTO, Root>()
                .ForMember(d => d.Sender_name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.Sender_identification, o => o.MapFrom(s => s.Identification))
                .ForMember(d => d.Sender_ie, o => o.MapFrom(s => s.IE))
                .ForMember(d => d.Sender_address, o => o.MapFrom(s => s.Address))
                .ForMember(d => d.Sender_number, o => o.MapFrom(s => s.Number))
                .ForMember(d => d.Sender_neighborhood, o => o.MapFrom(s => s.Neighborhood))
                .ForMember(d => d.Sender_county, o => o.MapFrom(s => s.County))
                .ForMember(d => d.Sender_cep, o => o.MapFrom(s => s.CEP))
                .ForMember(d => d.Sender_uf, o => o.MapFrom(s => s.UF)).ReverseMap();

            CreateMap<AddresseeDTO, Root>()
              .ForMember(d => d.Addressee_name, o => o.MapFrom(s => s.Name))
              .ForMember(d => d.Addressee_identification, o => o.MapFrom(s => s.Identification))
              .ForMember(d => d.Addressee_ie, o => o.MapFrom(s => s.IE))
              .ForMember(d => d.Addressee_address, o => o.MapFrom(s => s.Address))
              .ForMember(d => d.Addressee_number, o => o.MapFrom(s => s.Number))
              .ForMember(d => d.Addressee_neighborhood, o => o.MapFrom(s => s.Neighborhood))
              .ForMember(d => d.Addressee_county, o => o.MapFrom(s => s.County))
              .ForMember(d => d.Addressee_cep, o => o.MapFrom(s => s.CEP))
              .ForMember(d => d.Addressee_uf, o => o.MapFrom(s => s.UF)).ReverseMap();

            CreateMap<VolumeDTO, Root>()
             .ForMember(d => d.Additional_information, o => o.MapFrom(s => s.Additional_Information))
             .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
             .ForMember(d => d.Volume, o => o.MapFrom(s => s.Vol))
             .ForMember(d => d.Weight, o => o.MapFrom(s => s.Weight)).ReverseMap();



        }
    }
}
