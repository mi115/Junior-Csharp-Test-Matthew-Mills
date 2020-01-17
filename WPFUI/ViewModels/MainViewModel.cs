using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFUI.Models;
using static WPFUI.Database;
using WPFUI;
using MySql.Data.MySqlClient;

namespace WPFUI.ViewModels
{
	public class MainViewModel : Screen
	{
		private List<OrderModel> _order;
		private OrderModel _selectedOrder = new OrderModel();
		private CustomerModel _selectedCustomer;
		private List<EmployeeModel> employees;
		private EmployeeModel _selectedEmployee;
		private DateTime _fromdate;
		private DateTime _appliedDateFilter;
		private string _statusBar;

		public MainViewModel()
		{
			Database db = new Database();
			if (db.IsAvailable())
			{
				Order = db.GetAllOrders();
				Employees = db.GetAllEmployees();
				StatusBar = "Ready";
			}
			else 
			{
				MessageBox.Show("Failed to establish Database Connection");
			}
		}

		public void ReloadOrders()
		{
			Database db = new Database();
			if (db.IsAvailable())
			{
				DateTime IfFromDate = new DateTime(1, 1, 1);
				if (FromDate.Date == IfFromDate.Date)
				{
					Order = db.GetAllOrders();
					StatusBar = "Orders Reloaded";
				}
				else
				{
					Order = db.GetOrdersAfterDate(FromDate.Date);
					StatusBar = $"Reloaded Orders Filtered to Dates After { FromDate.Date }";
				}
			}
			else
			{
				MessageBox.Show("Failed to establish Database Connection");
			}

		}

		public void ClearOrdersFilter()
		{
			Database db = new Database();
			if (db.IsAvailable())
			{
				Order = db.GetAllOrders();
				FromDate = new DateTime(1, 1, 1);
				StatusBar = "Date Filter Cleared";
			}
			else 
			{
				MessageBox.Show("Failed to establish Database Connection");
			}
		}

		public void RefineOrdersByDate()
		{
			Database db = new Database();
			if (db.IsAvailable())
			{
				Order = db.GetOrdersAfterDate(FromDate.Date);
				StatusBar = $"Orders Filtered to Dates After { FromDate.Date }";
			}
			else 
			{
				MessageBox.Show("Failed to establish Database Connection");
			}
		}

		public DateTime FromDate
		{
			get 
			{
				return _fromdate; 
			}
			set 
			{
				_fromdate = value;
				NotifyOfPropertyChange(() => FromDate);
			}
		}

		public List<OrderModel> Order
		{
			get 
			{
				return _order; 
			}
			set 
			{
				_order = value;
				NotifyOfPropertyChange(() => Order);
			}
		}
		
		public List<EmployeeModel> Employees
		{
			get 
			{
				return employees; 
			}
			set 
			{ 
				employees = value; 
			}
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
				if (_selectedOrder == null)
				{
					SelectedCustomer = null;
					NotifyOfPropertyChange(() => SelectedCustomer);
					SelectedEmployee = null;
					NotifyOfPropertyChange(() => SelectedEmployee);
					StatusBar = "Not a valid Order Number within the filters applied.";
				}
				else 
				{
					Database db = new Database();
					_selectedCustomer = db.GetCustomerFromCustomerNumber(SelectedOrder.CustomerNumber);
					NotifyOfPropertyChange(() => SelectedCustomer);
					_selectedEmployee = Employees.Find(x => x.EmployeeNumber == SelectedOrder.EmployeeNumber);
					NotifyOfPropertyChange(() => SelectedEmployee);
					StatusBar = "Order Aquired";
				}
				
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
			get 
			{
				return _selectedEmployee; 
			}
			set {
				_selectedEmployee = value; 
			}
		}

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

		public string StatusBar
		{
			get 
			{
				return _statusBar; 
			}
			set 
			{
				_statusBar = value;
				NotifyOfPropertyChange(() => StatusBar);
			}
		}

		







	}
}
