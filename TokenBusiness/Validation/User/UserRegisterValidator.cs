using FluentValidation;
using TokenEntity.Dto.User;

namespace TokenBusiness.Validation.User
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("User name can not be null!")
                .Length(3, 25).WithMessage("User name length should be between 3-25 characters");
            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("User surname can not be null!")
                .Length(3, 25).WithMessage("User surname length should be between 3-25 characters");
            RuleFor(p => p.Gender).NotEmpty().WithMessage("Gender should be specified");
            RuleFor(p => p.IdentityNumber)
                .NotEmpty().WithMessage("Identity number should be specified.")
                .Length(11, 11).WithMessage("Identity number should be exact 11 character.");
        }
    }
}