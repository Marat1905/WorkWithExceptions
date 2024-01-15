using WorkWithExceptions.Common.Exceptions;

internal class Program
{
    private static void Main(string[] args)
    {
        Exception[] exceptions =
        {
            new ArgumentException ("Аргумент передаваемый в метод, является недопустимым"),
            new OverflowException ("Арифметическое, приведение или операция преобразования приводят к переполнению."),
            new DriveNotFoundException ("Диск недоступен или не существует."),
            new NotImplementedException ("Метод или операция не реализованы."),
            new CustomException ("Наше костомное исключение")
        };

            foreach (Exception exception in exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (Exception ex)
                {

                Console.WriteLine($" {ex.GetType()} - {ex.Message}") ;
                }
            }             
    }
}