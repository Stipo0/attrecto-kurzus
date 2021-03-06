using System.ComponentModel.DataAnnotations;

namespace Academy_2022.Models.Dto
{
    public class UserDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }


    }
}