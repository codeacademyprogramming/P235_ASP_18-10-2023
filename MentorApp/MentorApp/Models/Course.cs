using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorApp.Models
{
    public class Course :BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName ="money")]
        public double Price { get; set; }
        public int AvailableSeat { get; set; }
        [StringLength(100)]
        public string? Schedule { get; set; }
        

        public int? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        public IEnumerable<CourseSection>? CourseSections { get; set; }
    }
}
