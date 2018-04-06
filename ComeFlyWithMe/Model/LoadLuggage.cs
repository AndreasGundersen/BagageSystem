using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
    class LoadLuggage
    {
        //Fields
        private Queue<Luggage> destinationQueue;

        //Constructor
        public LoadLuggage()
        {

        }

        //Get-set method
        public Queue<Luggage> DestinationQueue { get => destinationQueue; set => destinationQueue = value; }

        //Event handler to update Viewmodel
        public event EventHandler LuggageLoaded;

        //Method that loads luggage when there is 5 or more in the destinationqueue
        public async void Load(Queue<Luggage> destination)
        {
            while (true)
            {
                DestinationQueue = destination;
                


                if (DestinationQueue.Count >= 5)
                {

                    for (int i = 0; i < DestinationQueue.Count; i++)
                    {
                        Debug.WriteLine(Task.CurrentId.ToString() + "   " + i);
                        Luggage luggage;
                        luggage = DestinationQueue.Dequeue();
                        LuggageLoaded?.Invoke(this, new LuggageEventArgs(luggage));

                    }
                }
                





                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }




    }
}
