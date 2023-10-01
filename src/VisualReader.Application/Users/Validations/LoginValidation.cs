using FluentValidation;
using VisualReader.Application.Constants;
using VisualReader.Application.Users.Commands;

namespace VisualReader.Application.Users.Validations
{
    public class LoginValidation : AbstractValidator<LoginRequest>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage(ExceptionErrorCode.ERROR_ENTITY_REQUIRED);
            RuleFor(x => x.Password).NotEmpty().WithMessage(ExceptionErrorCode.ERROR_ENTITY_REQUIRED);
        }
    }
}