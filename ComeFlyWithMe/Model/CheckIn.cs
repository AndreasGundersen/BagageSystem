using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	class CheckIn
	{
		public Queue<Luggage> luggageQueue = new Queue<Luggage>();

		public void OpenCheckIn()
		{
			//Tells this checkin thread to start
		}

		public void CloseCheckIn()
		{
			//Tells this checkin thread to sleep
		}

		public void GenerateLuggage(List<AvailableDestination> availableDestinations)
		{
			//Generate Luggage here
		}

	}
}
