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
		private int serialNumber;
		public Destination destination;

		public Luggage(Destination destination, int serialNumber)
		{
			Destination = destination;
			SerialNumber = serialNumber;
		}

		//Property
		public Destination Destination
		{
			get
			{
				return destination;
			}
			set
			{
				destination = value;
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
