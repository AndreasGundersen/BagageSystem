using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	class SortingMachine
	{
		public Queue<Luggage> LuggageSort = new Queue<Luggage>();

		public SortingMachine(Queue<Luggage> luggageSort)
		{
			LuggageSort = luggageSort;
		}

		public void GetLuggage()
		{
			//Get Luggage from Checkin.luggageQueue
		}
	}
}
