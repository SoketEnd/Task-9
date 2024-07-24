using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions = new Exception[5];
            exceptions[0] = new ArgumentNullException("Аргумент не должен быть null");
            exceptions[1] = new DivideByZeroException("Деление на ноль");
            exceptions[2] = new IndexOutOfRangeException("Индекс за пределами диапазона");
            exceptions[3] = new InvalidOperationException("Недопустимая операция");
            exceptions[4] = new MyCustomException("Это мое собственное исключение");

            foreach (var ex in exceptions)
            {
                try
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Произошло исключение: {e.Message}");
                }
                finally
                {
                    Console.WriteLine("Блок finally выполнен");
                }
            }
        }
    }
}
