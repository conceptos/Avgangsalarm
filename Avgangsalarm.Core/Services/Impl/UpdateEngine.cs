using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using System.Linq;
using Avgangsalarm.Core.Models;

namespace Avgangsalarm.Core.Services.Impl
{
	public class UpdateEngine : IUpdateEngine, IDisposable
	{
		private readonly ILocationRepository _locationRepository;
		private readonly IMonitorGeoFences _monitorGeoFences;
		private readonly IUpdateTrafikkdata _updateTrafikkData;
		private readonly IEnumerable<IPublishUpdates> _notifiers;
		private List<Departure> _departures = new List<Departure> (); 

		private readonly ILog _logger = LogManager.GetLogger(typeof(UpdateEngine));
		private bool _isStarted = false;

		public UpdateEngine (
			ILocationRepository locationRepository, 
			IMonitorGeoFences monitorGeoFences, 
			IUpdateTrafikkdata updateTrafikkData,
			IEnumerable<IPublishUpdates> notifiers)
		{
			_updateTrafikkData = updateTrafikkData;
			_monitorGeoFences = monitorGeoFences;
			_locationRepository = locationRepository;
			_notifiers = notifiers;

			monitorGeoFences.RegionEntered += OnRegionEntered;
			monitorGeoFences.RegionLeft += OnRegionLeft;
		}

		public void Start()
		{
			_isStarted = true;

			_logger.Info ("UpdateEngine: Starting engine...");

			AddAllLocationsToMonitor ();
		}

		public void Stop()
		{
			if (_isStarted) 
			{
				_logger.Info ("UpdateEngine: Stopping engine...");
				_isStarted = false;
			}

			RemoveAllLocationsFromMonitor ();
		}

		protected async void OnRegionEntered(object sender, Region e)
		{
			_logger.Info ("UpdateEngine: Region entered, fetching departures....");
			var departures = await _updateTrafikkData.GetDeparturesForStop (e.StopId);

			NotifyOfRelevantDepartures (e, departures);
		}

		void NotifyOfRelevantDepartures (Region e, IEnumerable<Departure> departures)
		{
			var locations = _locationRepository.FetchAll ().Where (i => i.Region == e);

			var relevantDepartures = new List<Departure> ();
			foreach (var location in locations) 
			{
				var departuresForStop = departures.Where (i => i.StopId == location.Region.StopId);
				location.UpdateDepartures (departuresForStop);
				var relevant = location.Departures;
				relevantDepartures.AddRange (relevant);
			}

			relevantDepartures = relevantDepartures.Distinct().ToList ();

			_logger.Info ("UpdateEngine: {0} relevant updates received", relevantDepartures.Count);

			if (_notifiers != null) 
			{
				foreach (var notifyer in _notifiers) 
				{
					notifyer.NotifyUpdatedDepartures (relevantDepartures);
				}			
			}			

		}

		protected void OnRegionLeft(object sender, Region e)
		{
			// TODO
		}

		private void AddAllLocationsToMonitor ()
		{
			var locations = _locationRepository.FetchAll ();
			foreach (var location in locations) 
			{
				_monitorGeoFences.AddRegion (location.Region);
			}
		}

		private void RemoveAllLocationsFromMonitor ()
		{
			var locations = _locationRepository.FetchAll ();
			foreach (var location in locations) 
			{
				_monitorGeoFences.RemoveRegion (location.Region);
			}
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			_monitorGeoFences.RegionEntered += OnRegionEntered;
			_monitorGeoFences.RegionLeft += OnRegionLeft;
		}

		#endregion
	}
}

