using System.Collections.Generic;

namespace Domain.Validation
{
    public class DomainValidationResult
    {
        public DomainValidationResult(ICollection<ValidationError> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        private DomainValidationResult()
        {
            ValidationErrors = new List<ValidationError>();
        }

        public bool Ok => ValidationErrors.Count == 0;

        public ICollection<ValidationError> ValidationErrors { get; }

        public static DomainValidationResult OkResult()
        {
            return new DomainValidationResult();
        }
    }
}