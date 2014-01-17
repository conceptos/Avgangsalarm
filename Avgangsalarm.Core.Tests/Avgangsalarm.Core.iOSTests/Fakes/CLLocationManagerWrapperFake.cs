using System;
using NUnit.Framework;
using Avgangsalarm.iOS;
using System.Linq;
using MonoTouch.CoreLocation;

namespace Avgangsalarm.Core.iOSTests.Fakes
{
	public class CLLocationManagerWrapperFake : ICLLocationManagerWrapper
	{
		#region ICLLocationManagerWrapper implementation

		public event EventHandler<CLRegionEventArgs> RegionEntered;

		public event EventHandler<CLRegionEventArgs> RegionLeft;

		public double DesiredAccuracy { get; set; }	

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

		#endregion

	}
	
}
