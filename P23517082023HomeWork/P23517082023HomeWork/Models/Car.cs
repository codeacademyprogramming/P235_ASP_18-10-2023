using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P23517082023HomeWork.Models
{
    public class Car
    {
        public int Id { get; set; }
        //[MaxLength(100)]
        [StringLength(100)]
        public string Name { get; set; }
        [Column( name:"Qiymet",TypeName = "smallmoney")]
        public double Price { get; set; }
        public int Year { get; set; }
        public int CarModelId { get; set; }

        public CarModel CarModel { get; set; }
    }
}
