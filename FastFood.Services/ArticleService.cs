using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class ArticleService
    {
        private readonly SqlHelper _sqlHelper;

        public ArticleService(string connectionString) {
            _sqlHelper = new SqlHelper(connectionString);
        }
    }
}
