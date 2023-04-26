using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ReturnDTO
    {
        public string message { get; set; }
        public int status { get; set; }
    }
    public class NextAccessDTO
    {
        public string message { get; set; }
        public string access_key { get; set; }
        public string expire_at { get; set; }
    }
}
