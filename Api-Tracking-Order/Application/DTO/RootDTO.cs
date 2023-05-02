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
        [JsonProperty("order_id")]
        public int OrderID { get; set; }
        [JsonProperty("document")]
        public string? KeyNF { get; set; }
        [JsonProperty("number_nf")]
        public string? NumberNF { get; set; }
        [JsonProperty("series_nf")]
        public string? SeriesNFE { get; set; }
        [JsonProperty("date_nf")]
        public DateTime DateNF { get; set; }
        [JsonProperty("date_inclusion")]
        public DateTime Date_Inclusion { get; set; }
        [JsonProperty("sender_name")]
        public string? Sender_name { get; set; }
        [JsonProperty("sender_identification")]
        public string? Sender_identification { get; set; }
        [JsonProperty("sender_ie")]
        public string? Sender_ie { get; set; }
        [JsonProperty("sender_address")]
        public string? Sender_address { get; set; }
        [JsonProperty("sender_number")]
        public string? Sender_number { get; set; }
        [JsonProperty("sender_neighborhood")]
        public string? Sender_neighborhood { get; set; }
        [JsonProperty("sender_county")]
        public string? Sender_county { get; set; }
        [JsonProperty("sender_cep")]
        public string? Sender_cep { get; set; }
        [JsonProperty("sender_uf")]
        public string? Sender_uf { get; set; }
        [JsonProperty("addressee_name")]
        public string? Addressee_name { get; set; }
        [JsonProperty("addressee_identification")]
        public string? Addressee_identification { get; set; }
        [JsonProperty("addressee_ie")]
        public string? Addressee_ie { get; set; }
        [JsonProperty("addressee_address")]
        public string? Addressee_address { get; set; }
        [JsonProperty("addressee_number")]
        public string? Addressee_number { get; set; }
        [JsonProperty("addressee_neighborhood")]
        public string? Addressee_neighborhood { get; set; }
        [JsonProperty("addressee_county")]
        public string? Addressee_county { get; set; }
        [JsonProperty("addressee_cep")]
        public string? Addressee_cep { get; set; }
        [JsonProperty("addressee_uf")]
        public string? Addressee_uf { get; set; }
        [JsonProperty("additional_information")]
        public string? Additional_information { get; set; }
        [JsonProperty("value")]
        public float Value { get; set; }
        [JsonProperty("volume")]
        public int Volume { get; set; }
        [JsonProperty("weight")]
        public float Weight { get; set; }
    }
}
