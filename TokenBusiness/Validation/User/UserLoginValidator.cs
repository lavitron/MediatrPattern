using FluentValidation;
using TokenEntity.Dto.User;

namespace TokenBusiness.Validation.User
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(p => p.IdentityNumber)
                .NotEmpty().WithMessage("Identity number should be filled.")
                .Length(11, 11).WithMessage("Identity number must be exact 11 character.");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Password should be filled.");
        }
    }
}