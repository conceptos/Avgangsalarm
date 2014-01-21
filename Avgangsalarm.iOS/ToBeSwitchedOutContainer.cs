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
					_monitorGeoFences = new MonitorGeoFences (CLLocationManagerWrapper);
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

		static ICLLocationManagerWrapper _cLLocationManagerWrapper;
		public static ICLLocationManagerWrapper CLLocationManagerWrapper {
			get 
			{	
				if (_cLLocationManagerWrapper == null) 
				{
					_cLLocationManagerWrapper = new CLLocationManagerWrapper ();
				}
				return _cLLocationManagerWrapper;
			}
			set 
			{
				_cLLocationManagerWrapper = value;
			}
		}
	}
}

