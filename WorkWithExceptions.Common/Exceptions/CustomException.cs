namespace WorkWithExceptions.Common.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() { }

        public CustomException(string? message) : base(message) { }

        public CustomException(string? message, Exception? innerException) : base(message, innerException) { }

        public override string Message => $"{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")} - {base.Message}" ;
    }
}
