using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Models
{
    public class Brand : BaseEntity
    {

        [StringLength(255,ErrorMessage ="Qaqa Maksimum 255 Simvol")]
        public string Name { get; set; }

        public IEnumerable<Product>? Products { get; set; }
    }
}
