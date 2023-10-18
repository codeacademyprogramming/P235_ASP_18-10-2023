using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Models
{
    public class Tag : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }
    }
}
