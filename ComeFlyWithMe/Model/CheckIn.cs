using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ComeFlyWithMe.Model
{

	public enum Destination
	{
		Bornholm, Rom, Paris, Kairo
	}

	class CheckIn
	{

		private int snum = 0;

		public Queue<Luggage> luggageQueue = new Queue<Luggage>();

		public CheckIn()
		{
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
				Random rnd = new Random();
				int num = rnd.Next(1, 5);

				Luggage l = new Luggage(Destination.Bornholm, snum);
				snum++;
				Luggage l1 = new Luggage(Destination.Kairo, snum);
				
				Luggage l2 = new Luggage(Destination.Paris, snum);
			
				Luggage l3 = new Luggage(Destination.Rom, snum);
				

				switch (num)
				{
					case 1:
						luggageQueue.Enqueue(l);
						Debug.WriteLine("Luggage to Bornholm " + snum);
						break;
					case 2:
						luggageQueue.Enqueue(l1);
						Debug.WriteLine("Luggage to Kairo " + snum);
						break;
					case 3:
						luggageQueue.Enqueue(l2);
						Debug.WriteLine("Luggage to Paris " + snum);
						break;
					case 4:
						luggageQueue.Enqueue(l3);
						Debug.WriteLine("Luggage to Rom " + snum);
						break;

					default:
						Debug.WriteLine("SENDS LUGGAGE TO HELL");
						break;
				}
				//await task to wait with more luggage
				await Task.Delay(TimeSpan.FromSeconds(0.5));


			}
		}

	}
}
