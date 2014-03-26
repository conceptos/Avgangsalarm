using Avgangsalarm.Core;
using Avgangsalarm.Core.Models;
using Avgangsalarm.WP8.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Avgangsalarm.WP8.ViewModels
{
    public class StoppestedViewModel : INotifyPropertyChanged
    {
        private Location _location;
        public Location Location
        {
            get { return _location; }
            set
            {
                if (value != _location)
                {
                    _location = value;
                    Name = _location.Name;
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private string _nextDepartures = AppResources.ContentPlaceholderNotInRegion;
        public string NextDepartures
        {
            get { return _nextDepartures; }
            set
            {
                if (value != _nextDepartures)
                {
                    _nextDepartures = value;
                    NotifyPropertyChanged("NextDepartures");
                }
            }
        }

        private List<Departure> _departures;
        public List<Departure> Departures
        {
            get { return _departures; }
            set
            {
                if (value != _departures)
                {
                    _departures = value;

                    if (!_departures.Any())
                        NextDepartures = AppResources.ContentPlaceholderNotInRegion;
                }
            }
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