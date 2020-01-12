using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Models
{
    public class CustomerModel
    {
		private int customer_number;
		private string forename;
		private string surname;
		private string telephone_number;

		public int CustomerNumber
		{
			get { return customer_number; }
			set { customer_number = value; }
		}

		public string Forename
		{
			get { return forename; }
			set { forename = value; }
		}

		public string Surname
		{
			get { return surname; }
			set { surname = value; }
		}

		public string TelephoneNumber
		{
			get { return telephone_number; }
			set { telephone_number = value; }
		}


	}
}
