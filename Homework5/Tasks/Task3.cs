using System;
using System.Data;

namespace DB.Lecture5.ADO.NET
{
    public class Task3 : TaskMain
    {

        public override void RunTask()
        {
            Console.WriteLine("Task 3");

            ADODataBase database = new ADODataBase();

            List<Analys> analysisResult = database.GetNonOrderedAnalysis();

            Console.WriteLine("Оберіть з свободних варіантів аналізів:");
            foreach (Analys analys in analysisResult)
            {
                Console.WriteLine($"ID аналізу: {analys.Id}, назва аналізу: {analys.anName}, ціна аналізу: {(int)analys.anPrice}");
            }

            Console.Write("Введіть номер дійсного аналізу для створення нового замовлення: ");

            int idInput = Int32.Parse(Console.ReadLine());

            Analys selectedAnalysis = analysisResult.FirstOrDefault(a => a.Id == idInput);
            Console.WriteLine(selectedAnalysis.anName);
            if (selectedAnalysis != null)
            {
                Order newOrder = new Order()
                {
                    orderDateTime = DateTime.Now,
                    orderAnId = selectedAnalysis.Id
                };

                database.AddOrder(newOrder);
            }
            else
            {
                Console.WriteLine("Аналіз з введеним ID не знайдено.");
                Console.Write("Введіть номер дійсного аналізу для створення нового замовлення: ");
            }
        }
    }
}
