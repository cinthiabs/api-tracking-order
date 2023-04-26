using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "This field {0} is required")]
        public string User { get; set; }
        [Required(ErrorMessage = "This field {0} is required")]
        public string Password { get; set; }
    }
}
