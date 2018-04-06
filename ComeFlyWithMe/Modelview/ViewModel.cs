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
        private ObservableCollection<Luggage> sortedSuitcasesBornholm;
        private ObservableCollection<Luggage> sortedSuitcasesKairo;
        private ObservableCollection<Luggage> sortedSuitcasesParis;
        private ObservableCollection<Luggage> sortedSuitcasesRom;
        private ObservableCollection<Luggage> loadedSuitcases;

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

        public ObservableCollection<Luggage> SortedSuitcasesBornholm
        {
            get
            {
                return sortedSuitcasesBornholm;
            }
            set
            {
                sortedSuitcasesBornholm = value;
                OnPropertyChanged(/*"SortedSuitcasesBornholm"*/);
            }
        }

        public ObservableCollection<Luggage> SortedSuitcasesKairo
        {
            get
            {
                return sortedSuitcasesKairo;
            }
            set
            {
                sortedSuitcasesKairo = value;
                OnPropertyChanged(/*"SortedSuitcasesKairo"*/);
            }
        }
        public ObservableCollection<Luggage> SortedSuitcasesParis
        {
            get
            {
                return sortedSuitcasesParis;
            }
            set
            {
                sortedSuitcasesParis = value;
                OnPropertyChanged(/*"SortedSuitcasesParis"*/);
            }
        }
        public ObservableCollection<Luggage> SortedSuitcasesRom
        {
            get
            {
                return sortedSuitcasesRom;
            }
            set
            {
                sortedSuitcasesRom = value;
                OnPropertyChanged(/*"SortedSuitcasesRom"*/);
            }
        }

        public ObservableCollection<Luggage> LoadedSuitcases
        {
            get
            {
                return loadedSuitcases;
            }
            set
            {
                loadedSuitcases = value;
                OnPropertyChanged(/*"LoadedSuitcases"*/);
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
            Suitcases = new ObservableCollection<Luggage>();



            SortingMachine sorter = new SortingMachine(checkIn1.luggageQueue);
            sorter.SuitcaseSorted += OnSuitcaseSorted;
            SortedSuitcasesBornholm = new ObservableCollection<Luggage>();
            SortedSuitcasesKairo = new ObservableCollection<Luggage>();
            SortedSuitcasesParis = new ObservableCollection<Luggage>();
            SortedSuitcasesRom = new ObservableCollection<Luggage>();
            LoadedSuitcases = new ObservableCollection<Luggage>();

            LoadLuggage loader = new LoadLuggage();
            loader.LuggageLoaded += OnLuggageLoaded;


            //Task to generate new Luggage
            Task t1 = new Task(checkIn1.GenerateLuggage);
            Task t2 = new Task(checkIn1.GenerateLuggage);
            //Task to sort luggage into destinationqueues 
            Task t3 = new Task(sorter.Sort);
            //Task to dequeue from destinationqueues 
            Task t4 = new Task(delegate { loader.Load(sorter.Bornholm); });
            Task t5 = new Task(delegate { loader.Load(sorter.Kairo); });
            Task t6 = new Task(delegate { loader.Load(sorter.Paris); });
            Task t7 = new Task(delegate { loader.Load(sorter.Rom); });

            //Starts the Tasks
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();
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

        private async void OnSuitcaseSorted(object sender, EventArgs e)
        {
            LuggageEventArgs lea = (LuggageEventArgs)e;

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    () =>
    {
        //Inserts the Luggage with its own parameters into the Collection
        if (lea.Luggage.Destination == "Bornholm")
        {
            SortedSuitcasesBornholm.Insert(0, lea.Luggage);
        }
        else if (lea.Luggage.Destination == "Kairo")
        {
            SortedSuitcasesKairo.Insert(0, lea.Luggage);
        }
        else if (lea.Luggage.Destination == "Paris")
        {
            SortedSuitcasesParis.Insert(0, lea.Luggage);
        }
        else if (lea.Luggage.Destination == "Rom")
        {
            SortedSuitcasesRom.Insert(0, lea.Luggage);
        }
        Suitcases.Remove(lea.Luggage);

    });
        }

        private async void OnLuggageLoaded(object sender, EventArgs e)
        {
            LuggageEventArgs llea = (LuggageEventArgs)e;

            //No idea what this does, but it fixes the crash
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
    () =>
    {
        //Inserts the Luggage with its own parameters into the Collection
        LoadedSuitcases.Insert(0, llea.Luggage);
        if (llea.Luggage == null)
        {
            return;
        }

        else { 
            if (llea.Luggage.Destination == "Bornholm")
        {
            SortedSuitcasesBornholm.Remove(llea.Luggage);
        }
        else if (llea.Luggage.Destination == "Kairo")
        {
            SortedSuitcasesKairo.Remove(llea.Luggage);
        }
        else if (llea.Luggage.Destination == "Paris")
        {
            SortedSuitcasesParis.Remove(llea.Luggage);
        }
        else if (llea.Luggage.Destination == "Rom")
        {
            SortedSuitcasesRom.Remove(llea.Luggage);
        }
        }
    });
        }

    }
}
