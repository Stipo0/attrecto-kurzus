using System.ComponentModel.DataAnnotations;

namespace Academy_2022.Models.Dto
{
    public class CourseDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
