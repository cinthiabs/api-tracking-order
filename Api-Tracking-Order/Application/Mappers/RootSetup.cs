using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers;

public class RootSetup : Profile
{
    public RootSetup()
    {
        CreateMap<RootDto, Root>()
            .ForMember(d => d.OrderID, o => o.MapFrom(r => r.OrderID))
            .ForMember(d => d.KeyNF, o => o.MapFrom(r => r.KeyNF))
            .ForMember(d => d.NumberNF, o => o.MapFrom(r => r.NumberNF))
            .ForMember(d => d.SeriesNFE, o => o.MapFrom(r => r.SeriesNFE))
            .ForMember(d => d.DateNF, o => o.MapFrom(r => r.DateNF))
            .ForMember(d => d.Date_Inclusion, o => o.MapFrom(r => r.Date_Inclusion))
            .ForMember(d => d.Addressee_name, o => o.MapFrom(s => s.Addressee_Name))
            .ForMember(d => d.Addressee_identification, o => o.MapFrom(s => s.Addressee_Identification))
            .ForMember(d => d.Addressee_ie, o => o.MapFrom(s => s.Addressee_IE))
            .ForMember(d => d.Addressee_address, o => o.MapFrom(s => s.Addressee_Address))
            .ForMember(d => d.Addressee_number, o => o.MapFrom(s => s.Addressee_Number))
            .ForMember(d => d.Addressee_neighborhood, o => o.MapFrom(s => s.Addressee_Neighborhood))
            .ForMember(d => d.Addressee_county, o => o.MapFrom(s => s.Addressee_Country))
            .ForMember(d => d.Addressee_cep, o => o.MapFrom(s => s.Addressee_Cep))
            .ForMember(d => d.Addressee_uf, o => o.MapFrom(s => s.Addressee_Uf))
            .ForMember(d => d.Additional_information, o => o.MapFrom(s => s.Additional_Information))
            .ForMember(d => d.Value, o => o.MapFrom(s => s.Value))
            .ForMember(d => d.Volume, o => o.MapFrom(s => s.Volume))
            .ForMember(d => d.Weight, o => o.MapFrom(s => s.Weight))
            .ForMember(d => d.Sender_name, o => o.MapFrom(s => s.Sender_name))
            .ForMember(d => d.Sender_identification, o => o.MapFrom(s => s.Sender_identification))
            .ForMember(d => d.Sender_ie, o => o.MapFrom(s => s.Sender_IE))
            .ForMember(d => d.Sender_address, o => o.MapFrom(s => s.Sender_Address))
            .ForMember(d => d.Sender_number, o => o.MapFrom(s => s.Sender_Number))
            .ForMember(d => d.Sender_neighborhood, o => o.MapFrom(s => s.Sender_Neighborhood))
            .ForMember(d => d.Sender_county, o => o.MapFrom(s => s.Sender_Country))
            .ForMember(d => d.Sender_cep, o => o.MapFrom(s => s.Sender_Cep))
            .ForMember(d => d.Sender_uf, o => o.MapFrom(s => s.Sender_Uf)).ReverseMap();
    }
}
