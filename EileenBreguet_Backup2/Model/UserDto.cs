using System.ComponentModel.DataAnnotations;

namespace Eileen_Breguet_LB295.Model
{
    public class UserDto
    {
        [Required]
        public  string Username { get; init; }
        [Required]
       public  string Password { get; init; }
    }
}
