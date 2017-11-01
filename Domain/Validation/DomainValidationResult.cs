namespace Domain.Validation
{
    public class DomainValidationResult
    {
        public string ErrorMessage { get; }
        private static string _validationErrorMessageOk = "Everything fine";

        public DomainValidationResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool Ok => ErrorMessage == _validationErrorMessageOk;

        public static DomainValidationResult OkResult()
        {
            return new DomainValidationResult(_validationErrorMessageOk);
        }
    }
}