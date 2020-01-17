using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Models
{
    public class OrderModel
    {
        
        private int order_number;
        private int customer_number;
        private int employee_number;
        private decimal sale_price;
        private DateTime order_date;

        public int Number { get => order_number; set => order_number = value; }
        public int CustomerNumber { get => customer_number; set => customer_number = value; }
        public int EmployeeNumber { get => employee_number; set => employee_number = value; }
        public decimal SalePrice { get => sale_price; set => sale_price = value; }
        public decimal Deposit { get; set; }

        public DateTime OrderDate
        {
            get { return order_date.Date; }
            set { order_date = value; }
        }


    }
}
