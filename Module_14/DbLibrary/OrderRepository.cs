using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DbLibrary
{
    //Connected approach
    public class OrderRepository<T> : IRepository<T> where T : OrderEntity
    {
        private static readonly string _connString = Properties.Settings.Default.OrderConnectionString;
        private readonly SqlConnection _sqlConnection = new SqlConnection(_connString);

        private void ExecuteQuery(string query)
        {
            _sqlConnection.Open();
            var command = new SqlCommand(query, _sqlConnection);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void InsertItem(T item)
        {
            var query = "INSERT INTO dbo.Orders " +
                        "(status, created_date, updated_date, product_id) " +
                        $"VALUES ({Convert.ToInt32(item.Status)}, '{item.CreatedDate}', '{item.UpdatedDate}', {item.ProductId})";

            ExecuteQuery(query);
        }

        public T SelectItemById(int itemId)
        {
            var query = "SELECT * FROM dbo.Orders " +
                        $"WHERE order_id = {itemId}";

            _sqlConnection.Open();
            var command = new SqlCommand(query, _sqlConnection);

            var dataReader = command.ExecuteReader();
            OrderEntity order = null;

            if (dataReader.Read())
            {
                order = new OrderEntity()
                {
                    OrderId = (int)dataReader[0],
                    Status = (Status)Convert.ToInt32(dataReader[1]),
                    CreatedDate = Convert.ToDateTime(dataReader[2].ToString()),
                    UpdatedDate = Convert.ToDateTime(dataReader[3]),
                    ProductId = Convert.ToInt32(dataReader[4])
                };
            }

            _sqlConnection.Close();

            return (T)order;
        }

        public List<T> SelectAll()
        {
            var query = "SELECT * " +
                        "FROM dbo.Orders";

            var command = new SqlCommand(query, _sqlConnection);
            _sqlConnection.Open();

            return ReturnDataReaderResult(command);
        }

        private List<T> ReturnDataReaderResult(SqlCommand command)
        {
            var ordersList = new List<T>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new[]
                    {
                        reader[0].ToString(),
                        reader[1].ToString(),
                        reader[2].ToString(),
                        reader[3].ToString(),
                        reader[4].ToString()
                    };

                    var product = ConvertToEntities(item);
                    ordersList.Add((T)product);
                }
            }

            _sqlConnection.Close();

            return ordersList;
        }

        private static T ConvertToEntities(string[] inputList)
        {
            var order = new OrderEntity()
            {
                OrderId = inputList[0] == null ? 0 : Convert.ToInt32(inputList[0]),
                Status = inputList[1] == null || inputList[1] == string.Empty ? 0 : (Status)Convert.ToInt32(inputList[1]),
                CreatedDate = Convert.ToDateTime(inputList[2]),
                UpdatedDate = Convert.ToDateTime(inputList[3]),
                ProductId = Convert.ToInt32(inputList[4])
            };

            return (T)order;
        }

        public void UpdateItem(T item)
        {
            var query = "UPDATE dbo.Orders " +
                        $"SET status = {Convert.ToInt32(item.Status)}, updated_date = '{item.UpdatedDate}', product_id = {item.ProductId} " +
                        $"WHERE order_id = {item.OrderId}";

            ExecuteQuery(query);
        }

        public void DeleteItem(int itemId)
        {
            var query = "DELETE FROM dbo.Orders " +
                        $"WHERE order_id = {itemId}";

            ExecuteQuery(query);
        }

        public List<T> SelectByFilter(string filterName, int value)
        {
            switch (filterName)
            {
                case "Status":
                    return ReturnStoredProcedureResult("SelectByStatus", "@status", value);
                case "Product":
                    return ReturnStoredProcedureResult("SelectByProductId", "@product_id", value);
                case "Month":
                    return ReturnStoredProcedureResult("SelectByMonth", "@month", value);
                case "Year":
                    return ReturnStoredProcedureResult("SelectByYear", "@year", value);

                default:
                    return new List<T>();
            }
        }

        private List<T> ReturnStoredProcedureResult(string commandName, string parameterName, int value)
        {
            var command = new SqlCommand()
            {
                CommandText = commandName,
                Connection = _sqlConnection,
                CommandType = CommandType.StoredProcedure
            };

            var parameter = new SqlParameter()
            {
                ParameterName = parameterName,
                Value = value,
                Direction = ParameterDirection.Input
            };

            command.Parameters.Add(parameter);
            _sqlConnection.Open();

            return ReturnDataReaderResult(command);
        }
    }
}
