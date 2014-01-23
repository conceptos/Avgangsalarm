using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using System.Collections.Generic;
using MonoTouch.CoreLocation;
using System.Linq;

namespace Avgangsalarm.iOS
{
	// http://docs.xamarin.com/guides/cross-platform/application_fundamentals/backgrounding/part_3_ios_backgrounding_techniques/updating_an_application_in_the_background/
	// http://docs.xamarin.com/guides/cross-platform/application_fundamentals/backgrounding/part_3_ios_backgrounding_techniques/registering_applications_to_run_in_background/
	public class MonitorGeoFences : IMonitorGeoFences, IDisposable
	{
		const int kilometer = 1000;
		private int _lastLocationId = 0;

		private readonly ILog _log;
		private Dictionary<Region, CLCircularRegion> Regions = new Dictionary<Region, CLCircularRegion> ();
		ICLLocationManagerWrapper _iPhoneLocationManager;	

		public MonitorGeoFences(ICLLocationManagerWrapper clLocationManagerWrapper)
		{
			_iPhoneLocationManager = clLocationManagerWrapper;
			_iPhoneLocationManager.DesiredAccuracy = kilometer * 0.25f;

			_iPhoneLocationManager.RegionEntered += OnRegionEntered;
			_iPhoneLocationManager.RegionLeft += OnRegionLeft;
			_iPhoneLocationManager.LocationsUpdated += OnLocationUpdated;

			_log = LogManager.GetLogger (this.GetType());
		}

		public IEnumerable<Region> GetRegions ()
		{
			return Regions.Select (i => i.Key);
		}

		protected void OnRegionEntered(object sender, CLRegionEventArgs e)
		{
			_log.Info ("MonitorGeoFences: Native event: Region entered");
			var region = GetRegion (e);
			RegionEntered (this, region);
		}

		protected void OnRegionLeft(object sender, CLRegionEventArgs e)
		{
			_log.Info ("MonitorGeoFences: Native event: Region left");
			var region = GetRegion (e);
			RegionLeft (this, region);
		}

		void OnLocationUpdated (object sender, CLLocationsUpdatedEventArgs e)
		{
			NativeLocationUpdatedEvent (this, e);
		}

		Region GetRegion (CLRegionEventArgs e)
		{
			var regionEntries = Regions.Where (i => i.Value == e.Region);

			if (regionEntries.Any()) 
			{
				return regionEntries.First().Key;
			}
			return null;
		}

		#region IMonitorGeoFences implementation

		public event EventHandler<Region> RegionEntered = delegate {};

		public event EventHandler<Region> RegionLeft = delegate {};

		public void AddRegion (Region region)
		{	
			var identifier = "MonitorRegion_" + (++_lastLocationId);
			_log.Info (string.Format ("MonitorGeoFences: Adding region {0}", identifier));

			var clCircularRegion = CreateNativeRegion (region, identifier);

			Regions.Add (region, clCircularRegion);
			_iPhoneLocationManager.StartMonitoring (clCircularRegion);
		}

		static CLCircularRegion CreateNativeRegion (Region region, string identifier)
		{
			var center = new CLLocationCoordinate2D {
				Longitude = region.Longitude,
				Latitude = region.Latitude
			};
			var clCircularRegion = new CLCircularRegion (center, region.AlertZoneRadiusInMeters, identifier);
			return clCircularRegion;
		}

		public event EventHandler<object> NativeLocationUpdatedEvent = delegate {};

		public void RemoveRegion (Avgangsalarm.Core.Region region)
		{
			var value = Regions[region];
			_log.Info (string.Format ("MonitorGeoFences: Adding region {0}", value.Identifier));

			_iPhoneLocationManager.StopMonitoring (value);
			Regions.Remove(region);
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			_iPhoneLocationManager.RegionEntered -= OnRegionEntered;
			_iPhoneLocationManager.RegionLeft -= OnRegionLeft;
		}

		#endregion
	}
}

