using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace VisualReader
{
    public class ImageValidation : AbstractValidator<UpdateProfileRequest>
    {
        public ImageValidation()
        {
            /*                RuleFor(request => request.AvatarFile)
                                .Cascade(CascadeMode.StopOnFirstFailure)
                                .NotNull()
                                .WithMessage("Avatar file is required.");
            */
            RuleFor(request => request.AvatarFile)
                .Must(HaveValidImageExtension)
                .When(request => request.AvatarFile != null)
                .WithMessage(ImageRegexConstant.ERROR_FORMAT_VALIDATION);
        }

        public override Task<ValidationResult> ValidateAsync(ValidationContext<UpdateProfileRequest> context, CancellationToken cancellation = new CancellationToken())
        {
            return base.ValidateAsync(context, cancellation);
        }

        private bool HaveValidImageExtension(IFormFile file)
        {
            if (file == null) return true;
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            return ImageRegexConstant.allowedExtensions.Contains(fileExtension);
        }
    }
}