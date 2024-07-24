using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_9
{
    class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
            
        }
    }
    class Program
    {
        public delegate void getName(string[] Name);
        static void ChekName(string[] Name)
        {
            //сортировка массива от А до Я 
            Array.Sort(Name, (x, y) => String.Compare(x, y)); 
            foreach (var item in Name)
            {
                Console.WriteLine(item);
            }
        }
        static void ChekNameRevers(string[] Name)
        {
            Array.Sort(Name, (x, y) => String.Compare(y, x));
            foreach (var item in Name)
            {
                Console.WriteLine(item);
            }
        }

        static string[] GetDisplay()
        {
            string[] Name = new string[5];
            Console.WriteLine("Напишите имена студентов ");
            for (int i = 0; i < Name.Length; i++)
            {
                Name[i] = Console.ReadLine();
            }
            return Name;
        }

        static void Main(string[] args)
        {
            
            string[] name = GetDisplay();

            Console.WriteLine("Введите 1 для сортировки от А до Я, 2 для сортировки от Я до А: ");

            try
            {
                int num = Convert.ToInt32(Console.ReadLine());

                if (num != 1 && num != 2)
                {
                    throw new InvalidInputException("Неверно введён аргумент. Введите 1 или 2.");
                }
                switch (num)
                {
                    case 1:
                        getName get = ChekName;
                        get(name);
                        break;
                    case 2:
                        getName get_2 = ChekNameRevers;
                        get_2(name);
                        break;
                }
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите число 1 или 2.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошло исключение: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен.");
            }
        }
    }
}
