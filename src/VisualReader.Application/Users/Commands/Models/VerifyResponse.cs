namespace VisualReader
{
    public class VerifyResponse : ResponseBase
    {
        public VerifyResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}