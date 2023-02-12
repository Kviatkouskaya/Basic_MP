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

            var query = "SELECT order_id AS OrderId, status, created_date, updated_date, product_id AS ProductId " +
                        "FROM Orders " +
                        "WHERE order_id = @OrderId";

            return dbConnection.Query<T>(query, new { OrderId = id }).FirstOrDefault();
        }

        public List<T> GetItems()
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var query = "SELECT order_id AS OrderId, status, created_date, updated_date, product_id AS ProductId FROM Orders";

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

        public List<T> SelectByFilter(string filterName, int value)
        {
            switch (filterName.ToUpper())
            {
                case "STATUS":
                    return ReturnStoredProcedureResult("SelectByStatus", "@status", value);
                case "PRODUCT":
                    return ReturnStoredProcedureResult("SelectByProductId", "@product_id", value);
                case "MONTH":
                    return ReturnStoredProcedureResult("SelectByMonth", "@month", value);
                case "YEAR":
                    return ReturnStoredProcedureResult("SelectByYear", "@year", value);
                default:
                    return new List<T>();
            }
        }

        private List<T> ReturnStoredProcedureResult(string procedureName, string filterName, int value)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add(filterName, value);

            return dbConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public void DeleteBulkByCriterion(string criterion, int value)
        {
            switch (criterion.ToUpper())
            {
                case "STATUS":
                    ExecuteBulkDeleteTransaction("DeleteByStatus", "@status", value);
                    break;
                case "PRODUCT":
                    ExecuteBulkDeleteTransaction("SelectByProductId", "@product_id", value);
                    break;
                case "MONTH":
                    ExecuteBulkDeleteTransaction("SelectByMonth", "@month", value);
                    break;
                case "YEAR":
                    ExecuteBulkDeleteTransaction("SelectByYear", "@year", value);
                    break;
            }
        }

        private void ExecuteBulkDeleteTransaction(string procedureName, string filterName, int value)
        {

            using IDbConnection dbConnection = new SqlConnection(_connectionString);

            var parameters = new DynamicParameters();
            parameters.Add(filterName, value);

            dbConnection.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
