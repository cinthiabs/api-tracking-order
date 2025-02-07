using System.ComponentModel.DataAnnotations;

namespace Application.Dto;

public class UserDto
{
    [Required(ErrorMessage = "This field {0} is required")]
    public string User { get; set; } = default!;
    [Required(ErrorMessage = "This field {0} is required")]
    public string Password { get; set; } = default!;
}
