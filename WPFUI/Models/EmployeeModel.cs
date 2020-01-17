using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Models
{
    public class EmployeeModel
    {
		private int employee_number;
		private string branch_name;
		private string postcode;

		public int EmployeeNumber
		{
			get { return employee_number; }
			set { employee_number = value; }
		}

		public string BranchName
		{
			get { return branch_name; }
			set { branch_name = value; }
		}

		public string Postcode
		{
			get { return postcode; }
			set { postcode = value; }
		}

	}
}
