using P235AllupDb.Models;
using P235AllupDb.ViewModels.BasketVMs;

namespace P235AllupDb.ViewModels.OrderVMs
{
    public class OrderVM
    {
        public Order Order { get; set; }
        public IEnumerable<BasketVM> BasketVMs { get; set; }
    }
}
