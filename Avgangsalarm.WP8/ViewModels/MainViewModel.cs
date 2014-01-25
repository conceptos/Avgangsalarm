using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Avgangsalarm.Core;
using Avgangsalarm.WP8.Resources;

namespace Avgangsalarm.WP8.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Stops = new ObservableCollection<StoppestedViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<StoppestedViewModel> Stops { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            foreach (var location in new DummyLocationRepository().FetchAll())
            {
                Stops.Add(new StoppestedViewModel { Location = location });
            }

            IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}