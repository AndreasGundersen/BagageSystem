using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	class Gate
	{
		//variables
		private int gateNumber;

		public Gate(int gateNumber, string destination)
		{
			GateNumber = gateNumber;
		}

		//Property
		public int GateNumber
		{
			get
			{
				return gateNumber;
			}
			set
			{
				gateNumber = value;
			}
		}

		public void OpenCheckIn()
		{
			//Tells this checkin thread to start
		}

		public void CloseCheckIn()
		{
			//Tells this checkin thread to sleep
		}
	}
}
