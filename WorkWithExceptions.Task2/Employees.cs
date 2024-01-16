using WorkWithExceptions.Common.Exceptions;

namespace WorkWithExceptions.Task2
{
    internal class Employees
    {
        /// <summary>Массив фамилий </summary>
        string[] Surnames { get; set; }

        /// <summary>Выбор метода сортировки 1 - по возрастанию;  2 - по убыванию</summary>
        private int _sorting;

        /// <summary>Выбор метода сортировки 1 - по возрастанию;  2 - по убыванию</summary>
        public int Sorting
        {
            get { return _sorting; }
            set 
            {
                switch (value)
                {
                    case 1:
                        SortAsc();
                        break;
                    case 2:
                        SortDesc();
                        break;
                    default:
                        throw new CustomException("Неверное значение сортировки");
                }
                _sorting = value;
            }
        }


        public delegate void SurnameDelegate(string sort);
        public event SurnameDelegate SurnameEvent;

        public Employees(string[] surnames)
        {
            Surnames=surnames;
        }

        /// <summary>Сортировка по возрастанию </summary>
        /// <param name="sorting"></param>
        private void SortAsc()
        {
            SurnameEvent?.Invoke("Сортировка по возрастанию");

            foreach (string s in Surnames.OrderBy(p=>p))
            {
                SurnameEvent?.Invoke(s);
            }
        }

        /// <summary>Сортировка по убыванию</summary>
        /// <param name="sorting"></param>
        private void SortDesc()
        {
            SurnameEvent?.Invoke("Сортировка по убыванию");

            foreach (string s in Surnames.OrderByDescending(p => p))
            {
                SurnameEvent?.Invoke(s);
            }
        }
    }
}
