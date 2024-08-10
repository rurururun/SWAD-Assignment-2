using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexWheels
{
	internal class Admin : Account
	{
		
        private string adminId;
		private string role;
		private DateTime lastActivityDate;

		public string AdminId
		{
			get { return adminId; }
			set { adminId = value; }
		}

		public string Role
		{
			get { return role; }
			set { role = value; }
		}

		public DateTime LastActivityDate
		{
			get { return lastActivityDate; }
			set { lastActivityDate = value; }
		}

		// Default constructor
		public Admin() { }

		// Parameterized constructor
		public Admin(string n, string cn, int i, string e, string pass, string id, string r, DateTime lad): base(n, cn, i, e, pass)
		{
			adminId = id;
			role = r;
			lastActivityDate = lad;
		}

		public override string ToString()
		{
			return base.ToString() + "\n" + $"Admin ID: {AdminId}, Role: {Role}, Last Activity Date: {LastActivityDate.ToShortDateString()}";
		}
	}
}