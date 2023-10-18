using System.ComponentModel.DataAnnotations;

namespace P235AllupDb.Areas.Manage.ViewModels.AccountVMs
{
    public class ResetPasswordVM
    {
        //public string Id { get; set; }
        //public string Token { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
