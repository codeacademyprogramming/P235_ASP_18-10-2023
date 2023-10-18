using System.ComponentModel.DataAnnotations;

namespace MentorApp.Models
{
    public class Trainer : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string SurName { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(1000)]
        public string Info { get; set; }
        [StringLength(255)]
        public string? FacebookUrl { get; set; }
        [StringLength(255)]
        public string? InstagramUrl { get; set; }
        [StringLength(255)]
        public string? LinkedinUrl { get; set; }
        [StringLength(255)]
        public string? TwitterUrl { get; set; }

        public int? CategroyId { get; set; }
        public Categroy? Categroy { get; set; }
    }
}
