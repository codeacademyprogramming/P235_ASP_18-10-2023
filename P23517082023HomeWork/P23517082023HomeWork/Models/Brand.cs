using System.ComponentModel.DataAnnotations;

namespace P23517082023HomeWork.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
    }
}
