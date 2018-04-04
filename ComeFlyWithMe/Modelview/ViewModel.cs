using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComeFlyWithMe.Model;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Windows.UI.Core;

namespace ComeFlyWithMe.Modelview
{
	public class ViewModel : ViewModelBase
	{
		//ObservableCollection for Luggage called suitcases
		private ObservableCollection<Luggage> suitcases;

		public ObservableCollection<Luggage> Suitcases
		{
			get
			{
				return suitcases;
			}
			set
			{
				suitcases = value;
				OnPropertyChanged(/*"Suitcases"*/);
			}
		}

		//Constucter for ViewModel
		public ViewModel()
		{
			//Creates a new CheckIn
			CheckIn checkIn1 = new CheckIn();
			//Subscribes OnSuitCaseArrived to checkin.SuitcaseArrived
			checkIn1.SuitcaseArrived += OnSuitcaseArrived;

			//Creates the ObservableColection with the Checkin LuggageQueue
			Suitcases = new ObservableCollection<Luggage>(checkIn1.luggageQueue);

			//Task to generate new Luggage
			Task t1 = new Task(checkIn1.GenerateLuggage);
			Task t2 = new Task(checkIn1.GenerateLuggage);

			//Starts the Task
			t1.Start();
			t2.Start();
		}

		private async void OnSuitcaseArrived(object sender, EventArgs e)
		{
			LuggageEventArgs lea = (LuggageEventArgs)e;

			//No idea what this does, but it fixes the crash
			await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
	() =>
	{
		//Inserts the Luggage with its own parameters into the Collection
		Suitcases.Insert(0, lea.Luggage);
	});
		}
	}
}
