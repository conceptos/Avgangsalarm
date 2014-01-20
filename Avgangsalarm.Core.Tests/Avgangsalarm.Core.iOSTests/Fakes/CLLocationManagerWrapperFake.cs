using System;
using NUnit.Framework;
using Avgangsalarm.iOS;
using System.Linq;
using MonoTouch.CoreLocation;
using System.Collections.Generic;

namespace Avgangsalarm.Core.iOSTests.Fakes
{
	public class CLLocationManagerWrapperFake : ICLLocationManagerWrapper
	{
		#region ICLLocationManagerWrapper implementation

		public event EventHandler<CLRegionEventArgs> RegionEntered;

		public event EventHandler<CLRegionEventArgs> RegionLeft;

		public event EventHandler<CLLocationsUpdatedEventArgs> LocationsUpdated;

		public double DesiredAccuracy { get; set; }	

		#endregion

		public void TriggerRegionEntered()
		{
			RegionEntered (this, CreateRegion());
		}

		public void TriggerRegionLeft()
		{
			RegionLeft (this, CreateRegion());
		}

		static CLRegionEventArgs CreateRegion ()
		{
			var coord = new CLLocationCoordinate2D ();
			var region = new CLCircularRegion (coord, 1, "2");
			return new CLRegionEventArgs (region);
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
	}
	
}
