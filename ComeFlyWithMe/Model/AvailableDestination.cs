using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	class AvailableDestination
	{
        //List of availableDestinations so we can add new destinations from the GUI
        private List<AvailableDestination> availableDestinations = new List<AvailableDestination>();
        public List<AvailableDestination> AvailableDestinations { get => availableDestinations; set => availableDestinations = value; }

        public AvailableDestination(List<AvailableDestination> aDestinations)
		{
			AvailableDestinations = aDestinations;
		}


        public void AddDestination()
		{
			//Add a destination to the availableDestinations List from GUI
		}
	}
}
