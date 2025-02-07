using Newtonsoft.Json;

namespace Application.Dto;

public class RootDto
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
    public string? Sender_IE { get; set; }
    [JsonProperty("sender_address")]
    public string? Sender_Address { get; set; }
    [JsonProperty("sender_number")]
    public string? Sender_Number { get; set; }
    [JsonProperty("sender_neighborhood")]
    public string? Sender_Neighborhood { get; set; }
    [JsonProperty("sender_country")]
    public string? Sender_Country { get; set; }
    [JsonProperty("sender_cep")]
    public string? Sender_Cep { get; set; }
    [JsonProperty("sender_uf")]
    public string? Sender_Uf { get; set; }
    [JsonProperty("addressee_name")]
    public string? Addressee_Name { get; set; }
    [JsonProperty("addressee_identification")]
    public string? Addressee_Identification { get; set; }
    [JsonProperty("addressee_ie")]
    public string? Addressee_IE { get; set; }
    [JsonProperty("addressee_address")]
    public string? Addressee_Address { get; set; }
    [JsonProperty("addressee_number")]
    public string? Addressee_Number { get; set; }
    [JsonProperty("addressee_neighborhood")]
    public string? Addressee_Neighborhood { get; set; }
    [JsonProperty("addressee_country")]
    public string? Addressee_Country { get; set; }
    [JsonProperty("addressee_cep")]
    public string? Addressee_Cep { get; set; }
    [JsonProperty("addressee_uf")]
    public string? Addressee_Uf { get; set; }
    [JsonProperty("additional_information")]
    public string? Additional_Information { get; set; }
    [JsonProperty("value")]
    public float Value { get; set; }
    [JsonProperty("volume")]
    public int Volume { get; set; }
    [JsonProperty("weight")]
    public float Weight { get; set; }
}