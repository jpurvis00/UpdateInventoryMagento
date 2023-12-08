
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class OracleCrud
    {
        private readonly string _connectionString;
        private OracleDataAccess _db = new OracleDataAccess();

        public OracleCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<InventoryModel> GetInventoryQuantities()
        {
            string sql = "select sku, quantity from V_MAGENTO_STOCK_DEFAULT";

            return _db.LoadData<InventoryModel, dynamic>(sql, new { }, _connectionString);
        }
    }
}
