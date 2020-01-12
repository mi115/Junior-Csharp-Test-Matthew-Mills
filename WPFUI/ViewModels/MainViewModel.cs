using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;
using static WPFUI.Database;


namespace WPFUI.ViewModels
{
    public class MainViewModel : Screen
    {
		private List<OrderModel> _order = new List<OrderModel>();
		private OrderModel _selectedOrder;
		private CustomerModel _selectedCustomer;
		private List<EmployeeModel> employees;

		public MainViewModel()
		{
			Database db = new Database();
			Order = db.GetAllOrders();
			Employees = db.GetAllEmployees();
			var result = Employees;
			
		}
		
		public List<OrderModel> Order
		{
			get { return _order; }
			set { _order = value; }
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

		private BranchModel _selectedBranch;

		public BranchModel SelectedBranch
		{
			get 
			{ 
				return _selectedBranch; 
			}
			set 
			{
				_selectedBranch = value; 
			}
		}

		private EmployeeModel _selectedEmployee;

		public EmployeeModel SelectedEmployee
		{
			get { return _selectedEmployee; }
			set { _selectedEmployee = value; }
		}





	}
}
