namespace VisualReader
{
    public class RegexConstants
    {
        public const string REGEX_PASSWORD = @"^(?=.*[A-Z])(?=.[a-z])(?=.*\d)(?![\W_]).{8,20}$";
        public const string REGEX_OTP = @" ^\d{6}$";
    }
}