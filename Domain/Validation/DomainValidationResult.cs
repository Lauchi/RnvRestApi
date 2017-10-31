using System.Collections.Generic;

namespace Domain.Validation
{
    public class DomainValidationResult
    {
        public bool Ok => ValidationErrors.Count == 0;

        public ICollection<ValidationError> ValidationErrors { get; } = new List<ValidationError>();

        public static DomainValidationResult OkResult()
        {
            return new DomainValidationResult();
        }
    }
}