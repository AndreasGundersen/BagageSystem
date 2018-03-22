using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComeFlyWithMe.Model;
using System.Diagnostics;

namespace ComeFlyWithMe.ViewModel
{
	class ViewModel
	{
        string test = "Aben er en abe";
        public ViewModel()
		{
			Debug.WriteLine("Fucking shit fuck");

			CheckIn checkIn1 = new CheckIn();

            


			Task t1 = new Task(checkIn1.GenerateLuggage);
            Task t2 = new Task(checkIn1.GenerateLuggage);

			t1.Start();
            t2.Start();

		}

        public string Test { get => test; set => test = value; }
    }
}
