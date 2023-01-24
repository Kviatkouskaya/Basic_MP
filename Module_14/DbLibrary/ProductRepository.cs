using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DbLibrary
{
    //Disconnected approach
    public class ProductRepository<T> : IRepository<T> where T : ProductEntity
    {
        private readonly string _connString = Properties.Settings.Default.OrderConnectionString;
        private SqlConnection _connection;
        private SqlDataAdapter _dataAdapter;
        private SqlCommandBuilder _builder;
        private DataSet _dataSet;
        private const string TableName = "Products";


        private void FetchData()
        {
            _connection = new SqlConnection(_connString);
            _connection.Open();

            _dataAdapter = new SqlDataAdapter($"SELECT * FROM {TableName}", _connection);

            _builder = new SqlCommandBuilder(_dataAdapter);

            _dataSet = new DataSet();

            _dataAdapter.Fill(_dataSet, TableName);
        }

        public void InsertItem(T item)
        {
            FetchData();

            var dataRow = _dataSet.Tables[TableName].NewRow();

            dataRow[0] = item.ProductId;
            dataRow[1] = item.Name;
            dataRow[2] = item.Description;
            dataRow[3] = item.Weight;
            dataRow[4] = item.Height;
            dataRow[5] = item.Length;
            dataRow[6] = item.Width;

            _dataSet.Tables[TableName].Rows.Add(dataRow);

            _builder.GetInsertCommand();

            _dataAdapter.Update(_dataSet, TableName);

            _connection.Close();
        }

        public T SelectItemById(int itemId)
        {
            FetchData();
            ProductEntity product = null;

            foreach (DataRow dataRow in _dataSet.Tables[TableName].Rows)
            {
                var id = dataRow[0] == null ? 0 : Convert.ToInt32(dataRow[0]);

                if (id == itemId)
                {
                    product = ConvertToProductEntity(dataRow.ItemArray);
                }
            }

            _connection.Close();

            return (T)product;
        }

        public List<T> SelectAll()
        {
            FetchData();

            var productList = new List<T>();

            foreach (DataRow dataRow in _dataSet.Tables[0].Rows)
            {
                var product = ConvertToProductEntity(dataRow.ItemArray);
                productList.Add((T)product);
            }

            _connection.Close();

            return productList;
        }

        private ProductEntity ConvertToProductEntity(object[] item)
        {
            var product = new ProductEntity()
            {
                ProductId = item[0] == null ? 0 : Convert.ToInt32(item[0]),
                Name = item[1].ToString(),
                Description = item[2].ToString(),
                Height = item[3] == DBNull.Value ? 0 : Convert.ToInt32(item[3]),
                Weight = item[4] == DBNull.Value ? 0 : Convert.ToInt32(item[4]),
                Length = item[5] == DBNull.Value ? 0 : Convert.ToInt32(item[5]),
                Width = item[6] == DBNull.Value ? 0 : Convert.ToInt32(item[6]),
            };

            return product;
        }

        public void UpdateItem(T item)
        {
            FetchData();

            foreach (DataRow dataRow in _dataSet.Tables[TableName].Rows)
            {
                var itemId = dataRow[0] == null ? 0 : Convert.ToInt32(dataRow[0]);

                if (item.ProductId == itemId)
                {
                    dataRow[1] = item.Name;
                    dataRow[2] = item.Description;
                    dataRow[3] = item.Height;
                    dataRow[4] = item.Weight;
                    dataRow[5] = item.Length;
                    dataRow[6] = item.Width;
                }
            }

            _builder.GetUpdateCommand();

            _dataAdapter.Update(_dataSet, TableName);

            _connection.Close();
        }

        public void DeleteItem(int itemId)
        {
            FetchData();

            foreach (DataRow dataRow in _dataSet.Tables[TableName].Rows)
            {
                var id = dataRow[0] == null ? 0 : Convert.ToInt32(dataRow[0]);

                if (itemId == id)
                {
                    dataRow.Delete();
                    break;
                }
            }

            _builder.GetDeleteCommand();

            _dataAdapter.Update(_dataSet, "Products");

            _connection.Close();
        }
    }
}
