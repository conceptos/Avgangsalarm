using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using System.Collections.Generic;
using MonoTouch.CoreLocation;
using System.Linq;

namespace Avgangsalarm.iOS.Services.Impl
{
	public class CLLocationManagerGateway : ICLLocationManagerGateway
	{
		CLLocationManager _clLocationManager;
		public CLLocationManagerGateway()
		{
			_clLocationManager = new CLLocationManager ();
			WrapEvents ();
		}

		void WrapEvents ()
		{
			_clLocationManager.RegionEntered += (object sender, CLRegionEventArgs e) =>  {
				this.RegionEntered (sender, e);
			};
			_clLocationManager.RegionLeft += (object sender, CLRegionEventArgs e) =>  {
				this.RegionLeft (sender, e);
			};

			_clLocationManager.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) => { 
				this.LocationsUpdated(sender, e);
			};
		}

		#region ICLLocationManagerWrapper implementation

		public event EventHandler<CLRegionEventArgs> RegionEntered = delegate {};
		public event EventHandler<CLRegionEventArgs> RegionLeft = delegate {};
		public event EventHandler<CLLocationsUpdatedEventArgs> LocationsUpdated = delegate {};

		public double DesiredAccuracy 
		{
			get { return _clLocationManager.DesiredAccuracy; }
			set { _clLocationManager.DesiredAccuracy = value; }
		}

		public void StartMonitoring (CLRegion clCircularRegion)
		{
			_clLocationManager.StartMonitoring (clCircularRegion);
		}

		public void StopMonitoring (CLRegion clCircularRegion)
		{
			_clLocationManager.StopMonitoring (clCircularRegion);
		}

		public void StartUpdatingLocation ()
		{
			_clLocationManager.StartUpdatingLocation ();
		}

		public void StopUpdatingLocation ()
		{
			_clLocationManager.StopUpdatingLocation ();
		}
		#endregion


	}
}

