using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComeFlyWithMe.Model
{
	class CheckIn
	{
		//List of Destinations
        private List<string> destinations = new List<string>
    {
        "Bornholm", "Rom", "Paris", "Kairo"
    };
		public List<string> Destinations { get => destinations; set => destinations = value; }

		//EventHandler for when a Suitcase arrives
		public event EventHandler SuitcaseArrived;

        Random rnd = new Random();

		//Queue for our luggage
		public Queue<Luggage> luggageQueue = new Queue<Luggage>();

		//Constucter for CheckIn
        public CheckIn()
		{
            Destinations = destinations;
            
		}

		public void OpenCheckIn()
		{
			//Tells this checkin thread to start
		}

		public void CloseCheckIn()
		{
			//Tells this checkin thread to sleep
		}

		//Method to Generate Luggage
		public async void GenerateLuggage()
		{
			while (true)
			{
				//Gets a random Destination
                int num = rnd.Next(0, Destinations.Count());

                Luggage luggage;

				//Gives the Luggage a new ID
                uint id = IdGen.NewId();

				//Creates the Luggage with its Destination and ID
                luggage = new Luggage(destinations[num], id);
				//Puts in in queue
                luggageQueue.Enqueue(luggage);
				//Tells the ViewModel that a Suitcase arrived
                SuitcaseArrived?.Invoke(this, new LuggageEventArgs(luggage));

                //Debug for testing purposes
                Debug.WriteLine("Luggage for " + Destinations[num] + " " + id);


                //await task to wait with more luggage
                await Task.Delay(TimeSpan.FromSeconds(2));


			}
		}

	}
}
