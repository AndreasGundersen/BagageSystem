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
        private List<string> destinations = new List<string>
    {
        "Bornholm", "Rom", "Paris", "Kairo"
    };
        public event EventHandler SuitcaseArrived;

        Random rnd = new Random();
        

		public Queue<Luggage> luggageQueue = new Queue<Luggage>();

        
        public List<string> Destinations { get => destinations; set => destinations = value; }

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

		public async void GenerateLuggage()
		{
			while (true)
			{

                int num = rnd.Next(0, Destinations.Count());

                Luggage luggage;

                uint id = IdGen.NewId();

                luggage = new Luggage(destinations[num], id);
                luggageQueue.Enqueue(luggage);
                SuitcaseArrived?.Invoke(this, new LuggageEventArgs(luggage));

                Debug.WriteLine("Luggage for " + Destinations[num] + " " + id);
                
               
				//await task to wait with more luggage
				await Task.Delay(TimeSpan.FromSeconds(0.5));


			}
		}

	}
}
