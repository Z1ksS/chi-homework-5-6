using System;
using System.Data.SqlClient;
using System.Data;

namespace DB.Lecture5.ADO.NET
{
    public class ADODataBase
    {
        private const string CONNECTION_STRING = "data source=.;initial catalog=chi_test;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

        //Task 1
        public List<Order> GetOrdersLastYearViaReader()
        {
            string query = "SELECT * FROM Orders WHERE YEAR(ord_datetime) >= YEAR(DATEADD(year, -2, GETDATE()))";

            List<Order> orders = new List<Order>();
                
            using var connection = new SqlConnection(CONNECTION_STRING);
            using var command = connection.CreateCommand();

            command.CommandText = query;

            connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    Id = (int) reader["ord_id"],
                    orderDateTime = (DateTime) reader["ord_datetime"],
                    orderAnId = (int)reader["ord_an"]
                });
            }

            reader.Close();
            connection.Close();

            return orders;
        }

        public DataTable GetOrdersLastYearViaAdapter()
        {
            string query = "SELECT * FROM Orders WHERE YEAR(ord_datetime) >= YEAR(DATEADD(year, -2, GETDATE()))";

            using var connection = new SqlConnection(CONNECTION_STRING);

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "Orders");

            connection.Close();

            return dataSet.Tables["Orders"];
        }

        public List<Analys> GetNonOrderedAnalysis()
        {
            string query = "SELECT * FROM Analysis WHERE an_id NOT IN(SELECT ord_an FROM Orders)";

            List<Analys> analysis = new List<Analys>();

            using var connection = new SqlConnection(CONNECTION_STRING);
            using var command = connection.CreateCommand();

            command.CommandText = query;

            connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                analysis.Add(new Analys
                {
                    Id = (int) reader["an_id"],
                    anName = (string) reader["an_name"],
                    anCost = (decimal) reader["an_cost"],
                    anPrice = (decimal) reader["an_price"],
                    anGroup = (int) reader["an_group"]
                });
            }

            reader.Close();
            connection.Close();

            return analysis;
        } 

        public int AddOrder(Order order)
        {
            string query = "INSERT INTO Orders(ord_datetime, ord_an) VALUES(@ord_datetime, @ord_an)";

            using var connection = new SqlConnection(CONNECTION_STRING);
            using var command = connection.CreateCommand();

            command.CommandText = query;

            command.Parameters.Add(new SqlParameter("@ord_datetime", order.orderDateTime));
            command.Parameters.Add(new SqlParameter("@ord_an", order.orderAnId));

            connection.Open();

            var id = (int)(decimal) command.ExecuteScalar();

            connection.Close();

            return id;
        }

        public Order GetOrderWithId(int ordId)
        {
            string query = "SELECT * FROM Orders WHERE ord_id = @ordId";

            Order order = new Order();

            using var connection = new SqlConnection(CONNECTION_STRING);
            using var command = connection.CreateCommand();

            command.CommandText = query;

            command.Parameters.Add(new SqlParameter("@ordId", ordId));

            connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                order = new Order()
                {
                    Id = (int) reader["ord_id"],
                    orderDateTime = (DateTime) reader["ord_datetime"],
                    orderAnId = (int) reader["ord_an"]
                };
            }
            reader.Close();
            connection.Close();

            return order;
        }

        public List<Order> GetOrders()
        {
            string query = "SELECT * FROM Orders";

            List<Order> orders = new List<Order>();

            using var connection = new SqlConnection(CONNECTION_STRING);
            using var command = connection.CreateCommand();

            command.CommandText = query;

            connection.Open();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    Id = (int)reader["ord_id"],
                    orderDateTime = (DateTime)reader["ord_datetime"],
                    orderAnId = (int)reader["ord_an"]
                });
            }

            reader.Close();
            connection.Close();

            return orders;
        }

        public int UpdateOrder(Order order)
        {
            string query = "UPDATE Orders SET ord_datetime = @ord_datetime, ord_an = @ord_an WHERE ord_id = @ord_id";

            using var connection = new SqlConnection(CONNECTION_STRING);
            using var command = connection.CreateCommand();

            command.CommandText = query;

            command.Parameters.Add(new SqlParameter("@ord_datetime", order.orderDateTime));
            command.Parameters.Add(new SqlParameter("@ord_an", order.orderAnId));
            command.Parameters.Add(new SqlParameter("@ord_id", order.Id));

            connection.Open();

            var count = command.ExecuteNonQuery();
            return count;
        }

        public int DeleteOrder(Order order)
        {
            string query = "DELETE FROM Orders WHERE ord_id = @ord_id";

            using var connection = new SqlConnection(CONNECTION_STRING);
            using var command = connection.CreateCommand();

            command.CommandText = query;

            command.Parameters.Add(new SqlParameter("@ord_id", order.Id));

            connection.Open();

            var count = command.ExecuteNonQuery();
            return count;
        }
    }
}
