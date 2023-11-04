using FluentValidation;

namespace VisualReader
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