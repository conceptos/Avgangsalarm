using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using System.Collections.Generic;
using MonoTouch.CoreLocation;
using System.Linq;

namespace Avgangsalarm.iOS
{
	public class MonitorGeoFences : IMonitorGeoFences
	{
		const int kilometer = 1000;

		private readonly ILog _log;
		private Dictionary<Region, CLCircularRegion> Regions = new Dictionary<Region, CLCircularRegion> ();
		ICLLocationManagerWrapper _iPhoneLocationManager;

		public MonitorGeoFences() 
			: this(new CLLocationManagerWrapper()) { }

		public MonitorGeoFences(ICLLocationManagerWrapper clLocationManagerWrapper)
		{
			_iPhoneLocationManager = clLocationManagerWrapper;
			_iPhoneLocationManager.DesiredAccuracy = kilometer * 0.5f;

			_iPhoneLocationManager.RegionEntered += LocationEntered;
			_iPhoneLocationManager.RegionLeft += LocationLeft;

			_log = LogManager.GetLogger (this.GetType());
		}

		public IEnumerable<Region> GetRegions ()
		{
			return Regions.Select (i => i.Key);
		}

		public void LocationEntered(object sender, CLRegionEventArgs e)
		{
			_log.Info ("MonitorGeoFences: Native event: Region entered");
		}

		public void LocationLeft(object sender, CLRegionEventArgs e)
		{
			_log.Info ("MonitorGeoFences: Native event: Region left");
		}

		#region IMonitorGeoFences implementation

		public event EventHandler<Region> RegionEntered = delegate {};

		public event EventHandler<Region> RegionLeft = delegate {};

		public void AddRegion (Region region, string identifier)
		{	
			_log.Info (string.Format ("MonitorGeoFences: Adding region {0}", identifier));

			var clCircularRegion = CreateNativeRegion (region, identifier);

			Regions.Add (region, clCircularRegion);
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

		public void RemoveRegion (Avgangsalarm.Core.Region region)
		{
			var value = Regions[region];
			_log.Info (string.Format ("MonitorGeoFences: Adding region {0}", value.Identifier));

			Regions.Remove(region);
		}

		#endregion
	}
}

