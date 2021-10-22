namespace ContactsRegistration.Domain.Models
{
    /// <summary>
    /// Error Helper
    /// </summary>
    public class ErrorHelper
    {
        public static readonly ErrorHelper ErrorNullOrEmpty = new ErrorHelper("ERR0001", "Value cannot be null or empty.");
        public static readonly ErrorHelper ErrorInvalidCPF = new ErrorHelper("ERR0002", "CPF is invalid.");
        public static readonly ErrorHelper ErrorInvalidCNPJ = new ErrorHelper("ERR0003", "CNPJ is invalid.");

        public string ErrorCode { get; }
        public string Description { get; }

        private ErrorHelper(string errorCode, string description)
        {
            ErrorCode = errorCode;
            Description = description;
        }
    }
}
