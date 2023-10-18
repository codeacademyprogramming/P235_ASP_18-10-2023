using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorApp.Models
{
    public class Pricing :BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName ="money")]
        public double Price { get; set; }
        public bool IsAdvanced { get; set; }
        public bool IsFeatured { get; set; }

        public IEnumerable<PricingService>? PricingServices { get; set; }
    }
}
