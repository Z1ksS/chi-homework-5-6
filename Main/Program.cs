using System;

using DB.Lecture5.ADO.NET;
using DB.Lecture5.EF;

namespace DB.Lecture5.Main
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Clear();

            Console.WriteLine("Доступні платформи:");
            Console.WriteLine("1 - ADO.NET");
            Console.WriteLine("2 - EF");
            Console.Write("Введіть варіант:");

            int result = Int32.Parse(Console.ReadLine());

            Run(result);
        }

        public static void Run(int result)
        {
            switch (result)
            {
                case 1:
                    Console.Clear();
                    ANProgram.Main();
                    break;
                case 2:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Введіть правильний варіант з вище зазначених");
                    Console.ReadLine();
                    break;
            }
        }
    }
}