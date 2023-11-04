namespace VisualReader
{
    public class RegisterResponse : ResponseBase
    {
        public string UserId { get; set; }

        public RegisterResponse(bool isSuccess, string userid)
        {
            IsSuccess = isSuccess;
            UserId = userid;
        }
    }
}