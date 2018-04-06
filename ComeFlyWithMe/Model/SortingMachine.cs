using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
    class SortingMachine
    {

        //Fields
        public Queue<Luggage> LuggageSort = new Queue<Luggage>();

        public Queue<Luggage> Bornholm = new Queue<Luggage>();
        public Queue<Luggage> Kairo = new Queue<Luggage>();
        public Queue<Luggage> Paris = new Queue<Luggage>();
        public Queue<Luggage> Rom = new Queue<Luggage>();

        //Constuctor
        public SortingMachine(Queue<Luggage> luggageSort)
        {
            LuggageSort = luggageSort;
        }

        //Eventhandler that updates viewmodel
        public event EventHandler SuitcaseSorted;

        //Method that takes luggage from checkin (if there are any) and sort it into our destinations.
        public async void Sort()
        {
            while (true)
            {
                Luggage luggage;

                while (LuggageSort.Count < 1)
                {
                    await Task.Delay(1000);
                    //print evt. 
                }
                luggage = LuggageSort.Dequeue();
                Debug.WriteLine("Luggage taken from sorting buffer");
                if (luggage == null)
                {
                    return;
                }
                else
                {
                    if (luggage.Destination == "Bornholm")
                    {
                        Bornholm.Enqueue(luggage);
                        Debug.WriteLine(luggage.Destination + " Sorted into Bornholm");
                    }

                    else if (luggage.Destination == "Kairo")
                    {
                        Kairo.Enqueue(luggage);
                        Debug.WriteLine(luggage.Destination + " Sorted into Kairo");
                    }

                    else if (luggage.Destination == "Rom")
                    {
                        Rom.Enqueue(luggage);
                        Debug.WriteLine(luggage.Destination + " Sorted into Rom");
                    }

                    else if (luggage.Destination == "Paris")
                    {
                        Paris.Enqueue(luggage);
                        Debug.WriteLine(luggage.Destination + " Sorted into Paris");
                    }
                    SuitcaseSorted?.Invoke(this, new LuggageEventArgs(luggage));

                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }


    }
}
