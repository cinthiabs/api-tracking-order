using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ReturnSucessDTO
    {
        public string? Message { get; set; }
        public int Status { get; set; }
        public NextAccessDTO? Data { get; set; }
    }
    public class NextAccessDTO
    {
        public string? Message { get; set; }
        public string? Access_key { get; set; }
        public string? expire_at { get; set; }
    }
    public class ReturnDTO
    {
        public string? Message { get; set; }
        public int Status { get; set; }
    }
    public class ReturnTrackingDTO
    {
        public int Orderid { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int StatusID { get; set; }
    }
}
