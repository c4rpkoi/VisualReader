using VisualReader.Application.Constants;

namespace VisualReader.Application.Models.Errors
{
    public class EntityNotFoundException : ErrorResponseMessage
    {
        public EntityNotFoundException(string message = null, string detailCode = null, IDictionary<string, object> payload = null, Exception innerException = null) : base(ExceptionErrorCode.ERROR_ENTITY_NOT_FOUND, message, detailCode, payload, innerException)
        {
        }
    }
}