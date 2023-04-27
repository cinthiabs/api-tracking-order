using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class RootDTO
    {
        [JsonProperty("order")]
        public int OrderID { get; set; }
        [JsonProperty("key")]
        public string? KeyNF { get; set; }
        [JsonProperty("number_nf")]
        public string? NumberNF { get; set; }
        [JsonProperty("series_nf")]
        public string? SeriesNF { get; set; }
        [JsonProperty("tp_nf")]
        public int TpNF { get; set; }
        [JsonProperty("date_nf")]
        public DateTime DateNF { get; set; }
        [JsonProperty("date_inclusion")]
        public DateTime Date_Inclusion { get; set; }
        [JsonProperty("sender")]
        public SenderDTO? Sender { get; set; }
        [JsonProperty("addressee")]
        public AddresseeDTO? Addressee { get; set; }
        [JsonProperty("volume")]
        public VolumeDTO? Volume { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; } 

    }
    public class SenderDTO
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("identification")]
        public string? Identification { get; set; }
        [JsonProperty("ie")]
        public string? IE { get; set; }
        [JsonProperty("address")]
        public string? Address { get; set; }
        [JsonProperty("number")]
        public string? Number { get; set; }
        [JsonProperty("neighborhood")]
        public string?Neighborhood { get; set; }
        [JsonProperty("county")]
        public string? County { get; set; }
        [JsonProperty("cep")]
        public string? CEP { get; set; }
        [JsonProperty("uf")]
        public string? UF { get; set; }
    }
    public class AddresseeDTO
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("identification")]
        public string? Identification { get; set; }
        [JsonProperty("ie")]
        public string? IE { get; set; }
        [JsonProperty("address")]
        public string? Address { get; set; }
        [JsonProperty("number")]
        public string? Number { get; set; }
        [JsonProperty("neighborhood")]
        public string? Neighborhood { get; set; }
        [JsonProperty("county")]
        public string? County { get; set; }
        [JsonProperty("cep")]
        public string? CEP { get; set; }
        [JsonProperty("uf")]
        public string? UF { get; set; }
    }
    public class VolumeDTO
    {
        [JsonProperty("additional_information")]
        public string? Additional_Information { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("vol")]
        public string Vol { get; set; }
        [JsonProperty("weight")]
        public string Weight { get; set; }
    }
}
