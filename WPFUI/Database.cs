using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using WPFUI.Models;
using WPFUI.Properties;

namespace WPFUI
{
    public class Database
    {
        private readonly string _ConnectionString = Settings.Default.DbConnectionString;

        public MySqlConnection GetConnection => new MySqlConnection(_ConnectionString);


        public IEnumerable<dynamic> FetchAllBranches()
        {
            var dbConnection = new Database().GetConnection;
            dbConnection.Open();

            var sql = "SELECT * from branches";
            var result = dbConnection.Query(sql);

            dbConnection.Close();
            return result;
        }

        public List<OrderModel> GetAllOrders()
        {
            using ( var dbConnection = new Database().GetConnection)
            {
                dbConnection.Open();

                var sql = "SELECT order_number, customer_number, employee_number, sale_price, deposit FROM practicaltest.orders";
                var result = dbConnection.Query<OrderModel>(sql).ToList();

                return result;
            }
        }

        public CustomerModel GetCustomerFromCustomerNumber(int CustomerNumber)
        {
            using (var dbConnection = new Database().GetConnection)
            {
                dbConnection.Open();

                var sql = $"SELECT * FROM practicaltest.customers WHERE customer_number = '{ CustomerNumber }'";
                var result = dbConnection.Query<CustomerModel>(sql).FirstOrDefault();

                return result;
            }
        }


        public List<EmployeeModel> GetAllEmployees()
        {
            using (var dbConnection = new Database().GetConnection)
            {
                dbConnection.Open();

                var sql = "SELECT em.employee_number, br.branch_name, br.postcode FROM practicaltest.employees as em JOIN practicaltest.branches as br on em.branch_name = br.branch_name";
                var result = dbConnection.Query<EmployeeModel>(sql).ToList();

                return result;
            }
        }

        public List<OrderModel> GetOrdersAfterDate(DateTime date)
        {
            using (var dbConnection = new Database().GetConnection)
            {
                dbConnection.Open();
                string querydate = date.ToString("yyyy-MM-dd");
                string dateresult = querydate;
                

                var sql = $"SELECT order_number, customer_number, employee_number, sale_price, deposit FROM practicaltest.orders WHERE order_date >= '{ querydate }'";
                var result = dbConnection.Query<OrderModel>(sql).ToList();

                return result;
            }
        }

    }
}
