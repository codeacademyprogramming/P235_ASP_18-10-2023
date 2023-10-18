using FluentValidation;

namespace P235FirstApi.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(r=>r.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
