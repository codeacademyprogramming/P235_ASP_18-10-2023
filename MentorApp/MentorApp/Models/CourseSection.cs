using System.ComponentModel.DataAnnotations;

namespace MentorApp.Models
{
    public class CourseSection : BaseEntity
    {
        [StringLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [StringLength(255)]
        public string? Image { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
