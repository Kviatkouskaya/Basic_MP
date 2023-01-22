using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace DapperLibrary
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Create(T item)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Products (name, description, weight, height, width, length) " +
                        "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)";

            dbConnection.Execute(query, item);
        }

        public void Delete(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "DELETE FROM Products WHERE product_id = @ProductId";

            dbConnection.Query<T>(query, new { ProductId = id });
        }

        public T Get(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT product_id AS ProductId, name, description, weight, height, width, length FROM Products WHERE product_id = @ProductId";

            return dbConnection.Query<T>(query, new { ProductId = id }).FirstOrDefault();
        }

        public List<T> GetItems()
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT product_id AS ProductId, name, description, weight, height, width, length FROM Products";

            return dbConnection.Query<T>(query).ToList();
        }

        public void Update(T item)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "Update Products " +
                        "SET name = @Name, description = @Description, weight = @Weight, height = @Height, width = @Width, length = @Length " +
                        "WHERE product_id = @ProductId";

            dbConnection.Execute(query, item);
        }
    }
}
