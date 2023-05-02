using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ReturnDTO
    {
        public string? message { get; set; }
        public int status { get; set; }
    }
    public class NextAccessDTO
    {
        public string? message { get; set; }
        public string? access_key { get; set; }
        public string? expire_at { get; set; }
    }

    public class ReturnTrackingDTO
    {
        public int orderid { get; set; }
        public DateTime date { get; set; }
        public string? description { get; set; }
        public int statusID { get; set; }
    }
}
