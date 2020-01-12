using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Models
{
    public class BranchModel
    {
		private string branch_name;
		private string postcode;

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
