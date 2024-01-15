using System.ComponentModel.Design;
using WorkWithExceptions.Common.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkWithExceptions.Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int count = InputDigit(ValidDigit);

                string[] Surnames = new string[count];

                for (int i = 0; i < count; i++)
                {
                    int j = i+1;
                    Surnames[i] = InputSurname($"Введите фамилию сотрудника {j}: ");
                }

                Employees employees = new Employees(Surnames);
                employees.SurnameEvent += Employees_SurnameEvent;

                employees.Sorting = InputDigit(ValidSort,"Введите метод сортировки 1 - по возрастанию; 2 - по убыванию: ", "Введенное значение должно быть 1 или 2");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void Employees_SurnameEvent(string sort)
        {
            Console.WriteLine(sort);
        }


        /// <summary>Метод для получения количества персонала</summary>
        /// <param name="text">Текст для представления</param>
        /// <param name="message">Сообщение при ошибку</param>
        /// <returns>Количество персонала</returns>
        private static int InputDigit(Predicate<string?> predicante,string text= "Введите количество персонала: ", string message= "Введенное значение должно быть числом")
        {
            int count = 0;
            do
            {
                try
                {
                    Console.Write(text);
                    string? result = Console.ReadLine();
                    if (IsValid(result, message, predicante))
                        count = int.Parse(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }   
            } 
            while (count <= 0);

            return count;
        }

        /// <summary>Метод для получения фамилии с консоли</summary>
        /// <param name="text">Текст для представления</param>
        /// <param name="message">Сообщение при ошибку</param>
        /// <returns></returns>
        private static string InputSurname(string text, string message = "Фамилия не может быть null")
        {
            string? res = null;
            do
            {
                try
                {
                    Console.Write(text);
                    string? result = Console.ReadLine();
                    if (IsValid(result, message, ValidSurname))
                        res = result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (res == null);

            return res;
        }

        /// <summary>Метод для валидации числа</summary>
        /// <param name="digit">Текст который надо проверить что оно является числом</param>
        /// <returns></returns>
        private static bool ValidDigit(string? digit)
        {
            if (int.TryParse(digit, out int count))
            {
                return true;
            }
            return false;
        }

        /// <summary>Метод для валидации фамилии</summary>
        /// <param name="surname">Текст который надо проверить что оно является фамилией</param>
        /// <returns></returns>
        private static bool ValidSurname(string? surname)
        {
            if (!string.IsNullOrWhiteSpace(surname))
                return true;

            return false;
        }

        /// <summary>Метод для валидации сортировки</summary>
        /// <param name="surname">Текст который надо проверить что оно является фамилией</param>
        /// <returns></returns>
        private static bool ValidSort(string? sort)
        {
            if (int.TryParse(sort, out int count))
            {
                if(count == 1 || count == 2) return true;
            }
            return false;
        }

        /// <summary>Метод валидации</summary>
        /// <param name="input">Входящий текст</param>
        /// <param name="message">Сообщение при ошибке</param>
        /// <param name="predicate">Делегат для проверки валидации</param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private static bool IsValid(string? input,string message,Predicate<string?> predicate)
        {
            return predicate(input) != true ? throw new CustomException(message) : true;  
        }
    }
}