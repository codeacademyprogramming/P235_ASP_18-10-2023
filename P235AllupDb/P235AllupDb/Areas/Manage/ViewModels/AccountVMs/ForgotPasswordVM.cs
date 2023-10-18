using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Areas.Manage.ViewModels.AccountVMs
{
    public class ForgotPasswordVM
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
