using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	class Luggage
	{
		//Variables
		private string luggageDestination;
		private int serialNumber;

		//Property
		public string LuggageDestination
		{
			get
			{
				return luggageDestination;
			}
			set
			{
				luggageDestination = value;
			}
		}

		//Property
		public int SerialNumber
		{
			get
			{
				return serialNumber;
			}
			set
			{
				serialNumber = value;
			}
		}
	}
}
