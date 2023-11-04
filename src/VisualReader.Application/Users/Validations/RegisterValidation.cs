using FluentValidation;

namespace VisualReader
{
    public class RegisterValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterValidation()
        {
            RuleFor(request => request.Email)
                .NotEmpty().WithMessage(ExceptionErrorCode.ERROR_EMPTY_VALIDATION)
                .EmailAddress().WithMessage(ExceptionErrorCode.ERROR_FORMAT_VALIDATION);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ExceptionErrorCode.ERROR_EMPTY_VALIDATION)
                .Matches(RegexConstants.REGEX_PASSWORD).WithMessage(ExceptionErrorCode.ERROR_FORMAT_VALIDATION);
        }
    }
}