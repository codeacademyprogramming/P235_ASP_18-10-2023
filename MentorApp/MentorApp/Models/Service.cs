using System.ComponentModel.DataAnnotations;

namespace MentorApp.Models
{
    public class Service : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
