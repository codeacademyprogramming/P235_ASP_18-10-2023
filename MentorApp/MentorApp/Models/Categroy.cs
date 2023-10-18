using System.ComponentModel.DataAnnotations;

namespace MentorApp.Models
{
    public class Categroy : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
