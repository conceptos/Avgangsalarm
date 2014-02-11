using System;
using NUnit.Framework;
using Avgangsalarm.iOS;
using System.Linq;
using MonoTouch.CoreLocation;
using System.Collections.Generic;
using Avgangsalarm.iOS.Services;

namespace Avgangsalarm.Core.iOSTests.Fakes
{
	public class CLLocationManagerGatewayFake : ICLLocationManagerGateway
	{
		#region ICLLocationManagerWrapper implementation

		public event EventHandler<CLRegionEventArgs> RegionEntered;

		public event EventHandler<CLRegionEventArgs> RegionLeft;

		public event EventHandler<CLLocationsUpdatedEventArgs> LocationsUpdated;

		public double DesiredAccuracy { get; set; }	

		#endregion

		public void TriggerRegionEntered(Region r, string regionName)
		{
			RegionEntered (this, CreateRegion(r, regionName));
		}

		public void TriggerRegionLeft(Region r, string regionName)
		{
			RegionLeft (this, CreateRegion(r, regionName));
		}

		static CLRegionEventArgs CreateRegion (Region region, string name)
		{
			var coord = new CLLocationCoordinate2D {
				Latitude = region.Latitude,
				Longitude =  region.Longitude
			};
			var r = new CLCircularRegion (coord, region.AlertZoneRadiusInMeters, name);
			return new CLRegionEventArgs (r);
		}

		public IEnumerable<string> MonitoredRegionsAdded = new List<string> ();
		public void StartMonitoring (CLRegion clCircularRegion)
		{
			var list = (List<string>)MonitoredRegionsAdded;
			list.Add (clCircularRegion.Identifier);
		}

		public IEnumerable<string> MonitoredRegionsRemoved = new List<string> ();
		public void StopMonitoring (CLRegion clCircularRegion)
		{
			var list = (List<string>)MonitoredRegionsRemoved;
			list.Add (clCircularRegion.Identifier);
		}

		public void StartUpdatingLocation ()
		{
			throw new NotImplementedException();
		}

		public void StopUpdatingLocation ()
		{
			throw new NotImplementedException();
		}
	}
	
}
