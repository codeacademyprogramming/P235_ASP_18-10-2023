using FluentValidation;

namespace P235FirstApi.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
