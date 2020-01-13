using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFUI.Models;
using static WPFUI.Database;


namespace WPFUI.ViewModels
{
    public class MainViewModel : Screen
    {
		private List<OrderModel> _order;
		private OrderModel _selectedOrder;
		private CustomerModel _selectedCustomer;
		private List<EmployeeModel> employees;
		private EmployeeModel _selectedEmployee;

		public MainViewModel()
		{
			Database db = new Database();
			Order = db.GetAllOrders();
			Employees = db.GetAllEmployees();
			StatusBar = "Ready";
			
			
		}

		public void ClearOrdersFilter()
		{
			Database db = new Database();
			Order = db.GetAllOrders();
			FromDate = new DateTime(1, 1, 1);
			StatusBar = "Date Filter Cleared";
		}

		public void RefineOrdersByDate()
		{
			Database db = new Database();
			Order = db.GetOrdersAfterDate(FromDate.Date);
			StatusBar = $"Orders Filtered to Dates After { FromDate.Date }";
		}

		private DateTime _fromdate;

		public DateTime FromDate
		{
			get { return _fromdate; }
			set 
			{
				_fromdate = value;
				NotifyOfPropertyChange(() => FromDate);
			}
		}


		public List<OrderModel> Order
		{
			get { return _order; }
			set 
			{
				_order = value;
				NotifyOfPropertyChange(() => Order);
			}
		}
		
		public List<EmployeeModel> Employees
		{
			get { return employees; }
			set { employees = value; }
		}

		public OrderModel SelectedOrder
		{
			get 
			{
				return _selectedOrder; 
			}
			set 
			{
				_selectedOrder = value;
				NotifyOfPropertyChange(() => SelectedOrder);
				Database db = new Database();
				_selectedCustomer = db.GetCustomerFromCustomerNumber(SelectedOrder.CustomerNumber);
				NotifyOfPropertyChange(() => SelectedCustomer);
				_selectedEmployee = Employees.Find(x => x.EmployeeNumber == SelectedOrder.EmployeeNumber);
				NotifyOfPropertyChange(() => SelectedEmployee);
			}
		}

		public CustomerModel SelectedCustomer
		{
			get
			{
				return _selectedCustomer;
			}
			set
			{
				_selectedCustomer = value;
			}
		}
		
		public EmployeeModel SelectedEmployee
		{
			get { return _selectedEmployee; }
			set { _selectedEmployee = value; }
		}

		private DateTime _appliedDateFilter;

		public DateTime AppliedDateFilter
		{
			get 
			{ 
				return _appliedDateFilter.Date; 
			}
			set 
			{ 
				_appliedDateFilter = value;
			}
		}

		private string _statusBar;

		public string StatusBar
		{
			get { return _statusBar; }
			set 
			{
				_statusBar = value;
				NotifyOfPropertyChange(() => StatusBar);
			}
		}







	}
}
