using FluentValidation.Results;

namespace VisualReader
{
    public class EntityValidationException : ErrorResponseMessage
    {
        public IDictionary<string, string[]> Failures { get; }

        public EntityValidationException(string message = null, string detailCode = null, IDictionary<string, object> payload = null, Exception innerException = null) : base(ExceptionErrorCode.ERROR_ENTITY_VALIDATION, message, detailCode, payload, innerException)
        {
            Failures = new Dictionary<string, string[]>();
        }

        public EntityValidationException(List<ValidationFailure> failures, string message = null, string detailCode = null, IDictionary<string, object> payload = null, System.Exception innerException = null)
        : this(message, detailCode, payload, innerException)
        {
            IEnumerable<string> enumerable = failures.Select((ValidationFailure e) => e.PropertyName).Distinct();
            foreach (string propertyName in enumerable)
            {
                string[] value = (from e in failures
                                  where e.PropertyName == propertyName
                                  select e.ErrorMessage).ToArray();
                Failures.Add(propertyName, value);
            }

            if (failures.Any((ValidationFailure f) => f.ErrorMessage.Contains("NOT_FOUND") || f.ErrorMessage.Contains("SOME_ITEMS_DELETED")))
            {
                SetDetailCode("ERROR.ENTITY.VALIDATION.SOME_ITEMS_DELETED");
            }
        }
    }
}