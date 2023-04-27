using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //public class Root
    //{
    //    [JsonProperty("order")]
    //    public Order? Order { get; set; }
    //}
    //public class Order
    //{
    //    [JsonProperty("order")]
    //    public int OrderID { get; set; }
    //    [JsonProperty("key")]
    //    public string? KeyNF { get; set; }
    //    [JsonProperty("number_nf")]
    //    public int NumberNF { get; set; }
    //    [JsonProperty("series_nf")]
    //    public string? SeriesNF { get; set; }
    //    [JsonProperty("tp_nf")]
    //    public int TpNF { get; set; }
    //    [JsonProperty("date_nf")]
    //    public DateTime DateNF { get; set; }
    //    [JsonProperty("date_inclusion")]
    //    public DateTime Date_Inclusion { get; set; }
    //    [JsonProperty("sender")]
    //    public Sender? Sender { get; set; }
    //    [JsonProperty("addressee")]
    //    public Addressee? Addressee { get; set; }
    //    [JsonProperty("volume")]
    //    public Volume? Volume { get; set; }
    //    [JsonProperty("status")]
    //    public int Status { get; set; }

    //}
    //public class Sender
    //{
    //    [JsonProperty("name")]
    //    public string? Name { get; set; }
    //    [JsonProperty("identification")]
    //    public string? Identification { get; set; }
    //    [JsonProperty("ie")]
    //    public string? IE { get; set; }
    //    [JsonProperty("address")]
    //    public string? Address { get; set; }
    //    [JsonProperty("number")]
    //    public string? Number { get; set; }
    //    [JsonProperty("neighborhood")]
    //    public string? Neighborhood { get; set; }
    //    [JsonProperty("county")]
    //    public string? County { get; set; }
    //    [JsonProperty("cep")]
    //    public string? CEP { get; set; }
    //    [JsonProperty("uf")]
    //    public string? UF { get; set; }
    //}
    //public class Addressee
    //{
    //    [JsonProperty("name")]
    //    public string? Name { get; set; }
    //    [JsonProperty("identification")]
    //    public string? Identification { get; set; }
    //    [JsonProperty("ie")]
    //    public string? IE { get; set; }
    //    [JsonProperty("address")]
    //    public string? Address { get; set; }
    //    [JsonProperty("number")]
    //    public string? Number { get; set; }
    //    [JsonProperty("neighborhood")]
    //    public string? Neighborhood { get; set; }
    //    [JsonProperty("county")]
    //    public string? County { get; set; }
    //    [JsonProperty("cep")]
    //    public string? CEP { get; set; }
    //    [JsonProperty("uf")]
    //    public string? UF { get; set; }
    //}
    //public class Volume
    //{
    //    [JsonProperty("additional_information")]
    //    public string? Additional_Information { get; set; }
    //    [JsonProperty("value")]
    //    public float Value { get; set; }
    //    [JsonProperty("vol")]
    //    public int Vol { get; set; }
    //    [JsonProperty("weight")]
    //    public float Weight { get; set; }
    //}

    public class Root
    {
        public int OrderID { get; set; }
        public string Document { get; set; }
        public string KeyNF { get; set; }
        public string NumberNF { get; set; }
        public string SeriesNFE { get; set; }
        public int TpNF { get; set; }
        public int Cod_Mun { get; set; }
        public DateTime DateNF { get; set; }
        public DateTime Date_Inclusion { get; set; }
        public string Sender_name { get; set; }
        public string Sender_identification { get; set; }
        public string Sender_ie { get; set; }
        public string Sender_address { get; set; }
        public string Sender_number { get; set; }
        public string Sender_neighborhood { get; set; }
        public string Sender_county { get; set; }
        public string Sender_cep { get; set; }
        public string Sender_uf { get; set; }
        public string Addressee_name { get; set; }
        public string Addressee_identification { get; set; }
        public object Addressee_ie { get; set; }
        public string Addressee_address { get; set; }
        public string Addressee_number { get; set; }
        public string Addressee_neighborhood { get; set; }
        public string Addressee_county { get; set; }
        public string Addressee_cep { get; set; }
        public string Addressee_uf { get; set; }
        public string Additional_information { get; set; }
        public string Value { get; set; }
        public string Volume { get; set; }
        public string Weight { get; set; }
        public string StatusId { get; set; }

    }
}
