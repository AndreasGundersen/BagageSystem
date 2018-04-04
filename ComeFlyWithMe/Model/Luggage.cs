using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	public class Luggage
	{
		//Variables
		private uint serialNumber;
		public string destination;

		//Constucter for Luggage
		public Luggage(string destination, uint serialNumber)
		{
			Destination = destination;
			SerialNumber = serialNumber;
		}

		//Property
		public string Destination
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
		public uint SerialNumber
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
