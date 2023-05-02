using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Root
    {
        public int OrderID { get; set; }
        public string? Document { get; set; }
        public string? KeyNF { get; set; }
        public string? NumberNF { get; set; }
        public string? SeriesNFE { get; set; }
        public int TpNF { get; set; }
        public int Cod_Mun { get; set; }
        public DateTime DateNF { get; set; }
        public DateTime Date_Inclusion { get; set; }
        public string? Sender_name { get; set; }
        public string? Sender_identification { get; set; }
        public string? Sender_ie { get; set; }
        public string? Sender_address { get; set; }
        public string? Sender_number { get; set; }
        public string? Sender_neighborhood { get; set; }
        public string? Sender_county { get; set; }
        public string? Sender_cep { get; set; }
        public string? Sender_uf { get; set; }
        public string? Addressee_name { get; set; }
        public string? Addressee_identification { get; set; }
        public string? Addressee_ie { get; set; }
        public string? Addressee_address { get; set; }
        public string? Addressee_number { get; set; }
        public string? Addressee_neighborhood { get; set; }
        public string? Addressee_county { get; set; }
        public string? Addressee_cep { get; set; }
        public string? Addressee_uf { get; set; }
        public string? Additional_information { get; set; }
        public float? Value { get; set; }
        public int Volume { get; set; }
        public float Weight { get; set; }
        public int StatusId { get; set; }

    }
}
