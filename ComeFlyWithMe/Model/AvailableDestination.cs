using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	class AvailableDestination
	{
		public List<AvailableDestination> availableDestinations = new List<AvailableDestination>();

		public AvailableDestination(List<AvailableDestination> availableDestinations)
		{
			this.availableDestinations = availableDestinations;
		}

		public void AddDestination()
		{
			//Add a destination to the availableDestinations List from GUI
		}
	}
}
