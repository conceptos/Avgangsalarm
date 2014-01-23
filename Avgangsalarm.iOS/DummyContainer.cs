using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using Avgangsalarm.iOS.ServiceImpl;
using Avgangsalarm.Core.Services.Impl;

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

		static IUpdateNotificationScreen _updateNotificationScreen;
		public static IUpdateNotificationScreen UpdateNotificationScreen {
			get 
			{
				if (_updateNotificationScreen == null) 
				{
					_updateNotificationScreen = new UpdateNotificationScreen ();
				}
				return _updateNotificationScreen;
			}
			set 
			{
				_updateNotificationScreen = value;
			}
		}

		static ITrafikkDataAdapter _trafikkDataAdapter;
		public static ITrafikkDataAdapter TrafikkDataAdapter 
		{
			get 
			{
				if (_trafikkDataAdapter == null) 
				{
					var serializer = new TrafikkDataDeserializer ();
					TrafikkDataAdapter = new TrafikkDataAdapter (serializer);
				}
				return _trafikkDataAdapter;
			}
			set 
			{
				_trafikkDataAdapter = value;
			}
		}

		static IUpdateTrafikkdata _updateTrafikkData;
		public static IUpdateTrafikkdata UpdateTrafikkData 
		{
			get 
			{
				if (_updateTrafikkData == null) 
				{
					_updateTrafikkData = new UpdateTrafikkData (TrafikkDataAdapter);
				}
				return _updateTrafikkData;
			}
			set 
			{
				_updateTrafikkData = value;
			}
		}

		static IUpdateEngine _updateEngine;
		public static IUpdateEngine UpdateEngine {
			get 
			{
				if (_updateEngine == null) 
				{
					_updateEngine = new UpdateEngine (LocationRepository, MonitorGeoFences, UpdateTrafikkData);
				}
				return _updateEngine;
			}
			set 
			{
				_updateEngine = value;
			}
		}
	}
}

