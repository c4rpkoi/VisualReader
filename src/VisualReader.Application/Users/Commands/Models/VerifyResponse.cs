using VisualReader.Application.Models.Bases;

namespace VisualReader.Application.Users.Commands.Models
{
    public class VerifyResponse : ResponseBase
    {
        public VerifyResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}