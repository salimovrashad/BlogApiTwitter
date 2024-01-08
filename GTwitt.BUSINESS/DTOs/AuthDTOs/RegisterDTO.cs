using FluentValidation;

namespace GTwitt.BUSINESS.DTOs.AuthDTOs
{
	public class RegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(16);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2).MaximumLength(32);
            RuleFor(x => x.Username).NotEmpty().MinimumLength(6).MaximumLength(16);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4).MaximumLength(32);
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password).WithMessage("Passwords do not match.");
            RuleFor(x => x.BirthDay).NotEmpty();
        }
    }
}
