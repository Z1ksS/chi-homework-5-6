using System;

namespace DB.Lecture5.ADO.NET
{
    public class Task4 : TaskMain
    {
        public override void RunTask()
        {
            Console.WriteLine("Task 4");

            ADODataBase database = new ADODataBase();

            Console.WriteLine("Замовлення яке буде оновлено:");

            Order order = database.GetOrderWithId(2);
            List<Order> orders = new List<Order> { order };

            ListOrders(orders);

            order.orderDateTime = DateTime.Now;
            order.orderAnId = 1;

            int result = database.UpdateOrder(order);

            orders = database.GetOrders();
            ListOrders(orders);
        }

        private void ListOrders(List<Order> orders)
        {
            Console.WriteLine("Доступні замовлення:");

            foreach (Order order in orders)
            {
                Console.WriteLine($"ID замовлення: {order.Id}, дата замовлення: {order.orderDateTime.ToString("dd.MM.yyyy")}, номер аналізу: {order.orderAnId}");
            }
        }
    }
}
