using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;

namespace Avgangsalarm.Core.Services.Impl
{
	public class UpdateEngine : IUpdateEngine, IDisposable
	{
		private readonly ILocationRepository _locationRepository;
		private readonly IMonitorGeoFences _monitorGeoFences;
		private readonly IUpdateTrafikkdata _updateTrafikkData;

		private readonly ILog _logger = LogManager.GetLogger(typeof(UpdateEngine));
		private bool _isStarted = false;

		public UpdateEngine (
			ILocationRepository locationRepository, 
			IMonitorGeoFences monitorGeoFences, 
			IUpdateTrafikkdata updateTrafikkData)
		{
			_updateTrafikkData = updateTrafikkData;
			_monitorGeoFences = monitorGeoFences;
			_locationRepository = locationRepository;

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

		public void OnRegionEntered(object sender, Region e)
		{
			// TODO
		}

		public void OnRegionLeft(object sender, Region e)
		{
			// TODO
		}

		void AddAllLocationsToMonitor ()
		{
			var locations = _locationRepository.FetchAll ();
			foreach (var location in locations) 
			{
				_monitorGeoFences.AddRegion (location.Region);
			}
		}

		void RemoveAllLocationsFromMonitor ()
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

