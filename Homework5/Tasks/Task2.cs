using System;
using System.Data;

namespace DB.Lecture5.ADO.NET
{
    public class Task2 : TaskMain
    {

        public override void RunTask()
        {
            Console.WriteLine("Task 2");

            ADODataBase database = new ADODataBase();
            DataTable ordersResult = database.GetOrdersLastYearViaAdapter();

            foreach (DataRow row in ordersResult.Rows)
            {
                Console.WriteLine($"ID замовлення: {row["ord_id"]}, дата замовлення: { ((DateTime) row["ord_datetime"]).ToString("dd.MM.yyyy") }, номер аналізу: {row["ord_an"]}");
            }
        }
    }
}
