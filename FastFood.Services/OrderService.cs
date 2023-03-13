using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fast_food;


namespace FastFood.Services
{
    public class OrderService : IOrderService
    {
        private readonly ISqlHelper _sqlHelper;

        public OrderService(string connectionString) {
            _sqlHelper = new SqlHelper(connectionString);
        }

        public List<Ordine> GetAll() {
            var dt = _sqlHelper.GetAll("select * from Ordine;");
            var orders = new List<Ordine>();

            foreach (DataRow row in dt.Rows) {
                var id = Convert.ToInt32(row["ID"]);
                var data = Convert.ToDateTime(row["DataOra"]);
                orders.Add(new Ordine(id, data));
            }

            return orders;
        }
    }
}
