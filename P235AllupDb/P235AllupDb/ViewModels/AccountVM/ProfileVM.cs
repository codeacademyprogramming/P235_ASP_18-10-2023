using P235AllupDb.Models;

namespace P235AllupDb.ViewModels.AccountVM
{
    public class ProfileVM
    {
        public ProfileAccountVM ProfileAccountVM { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public Address Address { get; set; }
    }
}
