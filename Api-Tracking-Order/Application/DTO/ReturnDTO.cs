namespace Application.Dto;

public class ReturnSucessDto
{
    public string? Message { get; set; }
    public int Status { get; set; }
    public NextAccessDto? Data { get; set; }
}
public class NextAccessDto
{
    public string? Message { get; set; }
    public string? Access_key { get; set; }
    public string? expire_at { get; set; }
}
public class ReturnDto
{
    public string? Message { get; set; }
    public int Status { get; set; }
}
public class ReturnTrackingDto
{
    public int Orderid { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public int StatusID { get; set; }
}
