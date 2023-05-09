using System;
using System.Data;

namespace DB.Lecture5.ADO.NET
{
    public class ANProgram
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ADO.NET\nОберіть завдання:");
            Console.WriteLine("1 - Завдання 1(SqlCommand та SqlDataReader)");
            Console.WriteLine("2 - Завдання 2(SqlDataAdapter та DataSet)");
            Console.WriteLine("3 - Завдання 4(створення нового запису в таблиці Orders)");
            Console.WriteLine("4 - Завдання 5(оновлення одного з запису в таблиці Orders)");
            Console.WriteLine("5 - Завдання 6(видалення запису в таблиці Orders)");
            Console.Write("Введіть варіант:");

            int result = Int32.Parse(Console.ReadLine());

            Run(result);  
        }

        public static void Run(int result)
        {
            TaskRunner taskRunner = new TaskRunner();

            switch (result)
            {
                case 1:
                    Console.Clear();
                    taskRunner.Task = TaskRunner.Tasks.Task1;
                    taskRunner.SelectTask(taskRunner).RunTask();
                    WaitForInput();
                    break;
                case 2:
                    Console.Clear();
                    taskRunner.Task = TaskRunner.Tasks.Task2;
                    taskRunner.SelectTask(taskRunner).RunTask();
                    WaitForInput();
                    break;
                case 3:
                    Console.Clear();
                    taskRunner.Task = TaskRunner.Tasks.Task3;
                    taskRunner.SelectTask(taskRunner).RunTask();
                    break;
                case 4:
                    Console.Clear();
                    taskRunner.Task = TaskRunner.Tasks.Task4;
                    taskRunner.SelectTask(taskRunner).RunTask();
                    WaitForInput();
                    break;
                case 5:
                    Console.Clear();
                    taskRunner.Task = TaskRunner.Tasks.Task5;
                    taskRunner.SelectTask(taskRunner).RunTask();
                    WaitForInput();
                    break;
                default:
                    Console.WriteLine("\nВведіть правильний варіант з вище зазначених");
                    Console.ReadLine();
                    break;
            }
        }

        public static void WaitForInput()
        {
            Console.WriteLine("0 - повернутись до листа з завданнями");

            int result = Int32.Parse(Console.ReadLine());
            switch(result)
            {
                case 0:
                    Console.Clear();
                    Main();
                    break;
                default:
                    Console.WriteLine("\nВведіть правильний варіант з вище зазначених");
                    Console.ReadLine();
                    break;
            }
        }
    }
}