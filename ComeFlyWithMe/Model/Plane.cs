using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	class Plane
	{
		//variables
		private int planeID;
		private string planeDestination;
		//Countdown for plane to leave
		private int depatureTime;

		public Plane(int planeID, string planeDestination, int depatureTime)
		{
			PlaneID = planeID;
			PlaneDestination = planeDestination;
			DepatureTime = depatureTime;
		}

		//Property
		public int PlaneID
		{
			get
			{
				return planeID;
			}
			set
			{
				planeID = value;
			}
		}
		//Property
		public string PlaneDestination
		{
			get
			{
				return planeDestination;
			}
			set
			{
				planeDestination = value;
			}
		}
		//Property
		public int DepatureTime
		{
			get
			{
				return depatureTime;
			}
			set
			{
				depatureTime = value;
			}
		}
	}
}
