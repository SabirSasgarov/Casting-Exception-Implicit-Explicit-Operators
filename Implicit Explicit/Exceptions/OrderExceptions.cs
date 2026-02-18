using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implicit_Explicit.Exceptions
{
	internal class OrderExceptions : Exception
	{
		public OrderExceptions(string message) : base(message)
		{
		}
	}
}
