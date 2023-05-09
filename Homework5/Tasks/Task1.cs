using System;

namespace DB.Lecture5.ADO.NET
{
    public class Task1 : TaskMain
    {

        public override void RunTask()
        {
            Console.WriteLine("Task 1");

            ADODataBase database = new ADODataBase();
            List<Order> orders = database.GetOrdersLastYearViaReader();
            foreach (Order order in orders)
            {
                Console.WriteLine($"ID замовлення: {order.Id}, дата замовлення: {order.orderDateTime.ToString("dd.MM.yyyy")}, номер аналізу: {order.orderAnId}");
            }
        }
    }
}
