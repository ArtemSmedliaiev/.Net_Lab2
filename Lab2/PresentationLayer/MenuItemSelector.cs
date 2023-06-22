using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.PresentationLayer
{
    public class MenuItemSelector
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public MenuItemSelector(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public int SelectItem()
        {
            while (true)
            {
                Console.Write("\nОберіть пункт: ");
                string? readValue = Console.ReadLine();
                if (!IsConvertableToInt32(readValue))
                {
                    Console.WriteLine("Ви ввели не цілочислене значення\nСпробуйте знов");
                    continue;
                }

                int value = Convert.ToInt32(readValue);

                if (value < _minValue || value > _maxValue)
                {
                    Console.WriteLine("Ви обрали пункт, якого не має у меню\nСпробуйте знов");
                    continue;
                }
                return value - 1;
            }
        }

        public string GetCity()
        {
            Console.WriteLine("Введіть місто за яким шукати:");
            return Console.ReadLine();
        }

        public int GetMin()
        {
            Console.WriteLine("Введіть мінімальний наклад:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetMax()
        {
            Console.WriteLine("Введіть максимальний наклад:");
            return Convert.ToInt32(Console.ReadLine());
        }

        private bool IsConvertableToInt32(string? readValue)
        {
            if (readValue is null)
                return false;
            try
            {
                Convert.ToInt32(readValue);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }
    }
}
