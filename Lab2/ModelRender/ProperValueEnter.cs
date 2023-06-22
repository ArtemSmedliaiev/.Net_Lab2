using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.ModelRender
{
    internal class ProperValueEnter
    {
        public int IntValueEnter(string message)
        {
            while (true)
            {
                Console.Write(message);
                int value;
                string str = Console.ReadLine();

                try
                {
                    value = Convert.ToInt32(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nФормат введених даних не є int. Спробуйте знов");
                    continue;
                }

                return value;
            }
        }

        public float FloatValueEnter(string message)
        {
            while (true)
            {
                Console.Write(message);
                float value;
                string str = Console.ReadLine();

                try
                {
                    value = Convert.ToSingle(str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nФормат введених даних не є float. Спробуйте знов");
                    continue;
                }

                return value;
            }
        }

        public DateTime TimeValueEnter(string message)
        {
            while (true)
            {
                Console.Write(message);
                DateTime value;
                string str = Console.ReadLine();

                try
                {
                    value = Convert.ToDateTime(str);
                }
                catch
                {
                    Console.WriteLine("\nФормат введних даних не є DateTime. Спробуйте знов");
                    continue;
                }
                return value;
            }
        }

        public string StringValueEnter(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
