using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OrderRepository
    {
        private AppContext _context;

        public OrderRepository()
        {
            _context = new AppContext();
        }
        public void Create(OrderModel item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Orders.Remove(new OrderModel() { Id = id });
            _context.SaveChanges();
        }

        public OrderModel Get(int id)
        {
            return _context.Orders.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<OrderModel> GetItems()
        {
            return _context.Orders.ToList();
        }

        public void Update(OrderModel item)
        {
            _context.Orders.Update(item);
            _context.SaveChanges();
        }

        public List<OrderModel> SelectByFilter(string filterName, int value)
        {
            switch (filterName.ToUpper())
            {
                case "STATUS":
                    return ReturnStoredProcedureResult("SelectByStatus", value);
                case "PRODUCT":
                    return ReturnStoredProcedureResult("SelectByProductId", value);
                case "MONTH":
                    return ReturnStoredProcedureResult("SelectByMonth", value);
                case "YEAR":
                    return ReturnStoredProcedureResult("SelectByYear", value);
                default:
                    return new List<OrderModel>();
            }
        }

        private List<OrderModel> ReturnStoredProcedureResult(string procedureName, int value)
        {
            return _context.Orders.FromSql($"{procedureName} {value}").ToList();
        }

        public void DeleteBulkByCriterion(string criterion, int value)
        {
            switch (criterion.ToUpper())
            {
                case "STATUS":
                    ExecuteBulkDeleteTransaction("DeleteByStatus", value);
                    break;
                case "PRODUCT":
                    ExecuteBulkDeleteTransaction("SelectByProductId", value);
                    break;
                case "MONTH":
                    ExecuteBulkDeleteTransaction("SelectByMonth", value);
                    break;
                case "YEAR":
                    ExecuteBulkDeleteTransaction("SelectByYear", value);
                    break;
            }
        }

        private void ExecuteBulkDeleteTransaction(string procedureName, int value)
        {
            _context.Orders.FromSql($"{procedureName} {value}");
            _context.SaveChanges();
        }
    }
}
