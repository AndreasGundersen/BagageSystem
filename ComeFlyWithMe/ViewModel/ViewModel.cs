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

namespace ComeFlyWithMe.ViewModel
{
	class ViewModel : ViewModelBase
	{

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


        public ViewModel()
		{
			

			CheckIn checkIn1 = new CheckIn();
            checkIn1.SuitcaseArrived += OnSuitcaseArrived;
            
            Suitcases = new ObservableCollection<Luggage>(checkIn1.luggageQueue);


            Task t1 = new Task(checkIn1.GenerateLuggage);
            Task t2 = new Task(checkIn1.GenerateLuggage);

			t1.Start();
            t2.Start();


		}

        private async void OnSuitcaseArrived(object sender, EventArgs e)
        {
            LuggageEventArgs lea = (LuggageEventArgs)e;
            
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    () =>
    {
        Suitcases.Add(lea.Luggage);
    });
        }
    }
}
