using System;
using System.Collections.Generic;

namespace DB.Lecture5.ADO.NET
{
    public class Task5 : TaskMain
    {
        public override void RunTask()
        {
            Console.WriteLine("Task 5");

            ADODataBase database = new ADODataBase();

            List<Order> orders = database.GetOrders();

            ListOrders(orders);
            int result = WriteId();

            Order selectedOrder = orders.FirstOrDefault(a => a.Id == result);
            if (selectedOrder != null)
            {
                Order order = database.GetOrderWithId(selectedOrder.Id);
                database.DeleteOrder(order);

                orders = database.GetOrders();
                ListOrders(orders);
            } 
            else
            {
                Console.WriteLine("Аналіз з введеним ID не знайдено.");
                WriteId();
            }
        }

        private void ListOrders(List<Order> orders)
        {
            Console.WriteLine("Доступні замовлення:");

            foreach (Order order in orders)
            {
                Console.WriteLine($"ID замовлення: {order.Id}, дата замовлення: {order.orderDateTime.ToString("dd.MM.yyyy")}, номер аналізу: {order.orderAnId}");
            }
        }

        private int WriteId()
        {
            Console.Write("Введіть ID замовлення, щоб видалить його: ");

            int idInput = Int32.Parse(Console.ReadLine());

            return idInput; 
        }
    }
}
