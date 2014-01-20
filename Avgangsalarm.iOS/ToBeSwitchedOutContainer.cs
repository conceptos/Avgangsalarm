using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;

namespace Avgangsalarm.iOS
{
	public static class DummyContainer
	{
		static IMonitorGeoFences _monitorGeoFences;
		public static IMonitorGeoFences MonitorGeoFences 
		{
			get 
			{
				if (_monitorGeoFences == null) 
				{
					_monitorGeoFences = new MonitorGeoFences ();
				}

				return _monitorGeoFences;
			}
			set 
			{
				_monitorGeoFences = value;
			}
		}

		static ILocationRepository _locationRepository;
		public static ILocationRepository LocationRepository 
		{
			get 
			{
				if (_locationRepository == null) 
				{
					_locationRepository = new DummyLocationRepository ();
				}
				return _locationRepository;
			}
			set 
			{
				_locationRepository = value;
			}
		}
	}
}

