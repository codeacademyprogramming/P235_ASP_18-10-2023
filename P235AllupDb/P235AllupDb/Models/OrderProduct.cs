using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Models
{
    public class OrderProduct : BaseEntity
    {
        [StringLength(255)]
        public string Title { get; set; }
        [Column(TypeName = "money")]
        public double Price { get; set; }
        [Column(TypeName = "money")]
        public double ExTag { get; set; }
        public int Count { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
