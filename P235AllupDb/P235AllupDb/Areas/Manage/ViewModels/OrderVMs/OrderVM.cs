using P235AllupDb.Enums;
using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Areas.Manage.ViewModels.OrderVMs
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        [StringLength(255)]
        public string? Comment { get; set; }
        public OrderStatus Status { get; set; }
    }
}
