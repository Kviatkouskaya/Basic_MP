using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DapperLibrary
{
    public class OrderRepository<T> : IRepository<T> where T : Order
    {
        private readonly string _connectionString;

        public OrderRepository(string connection)
        {
            _connectionString = connection;
        }

        public void Create(T item)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Orders (status, created_date, updated_date, product_id)" +
                        "VALUES (@Status, @CreatedDate, @UpdatedDate, @ProductId)";

            dbConnection.Execute(query, item);
        }

        public void Delete(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "DELETE FROM Orders " +
                        "WHERE order_id = @OrderId";

            dbConnection.Query<T>(query, new { OrderId = id });
        }

        public T Get(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT order_id, status, created_date, updated_date, product_id " +
                        "FROM Orders " +
                        "WHERE order_id = @OrderId";

            return dbConnection.Query<T>(query, new { OrderId = id }).FirstOrDefault();
        }

        public List<T> GetItems()
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT * FROM Orders";

            return dbConnection.Query<T>(query).ToList();
        }

        public void Update(T item)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "Update Orders " +
                        "SET status = @Status, updated_date = @UpdatedDate, product_id = @ProductId " +
                        "WHERE order_id = @OrderId";

            dbConnection.Execute(query, item);
        }
    }
}
