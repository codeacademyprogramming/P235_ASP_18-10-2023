using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P23517082023HomeWork.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        //[ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        //relation object
        public Brand Brand { get; set; }
    }
}
