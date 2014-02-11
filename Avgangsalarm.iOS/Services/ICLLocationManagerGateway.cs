using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using System.Collections.Generic;
using MonoTouch.CoreLocation;
using System.Linq;

namespace Avgangsalarm.iOS.Services
{
	public interface ICLLocationManagerGateway
	{
		void StartMonitoring (CLRegion clCircularRegion);
		void StopMonitoring (CLRegion clCircularRegion);
		void StartUpdatingLocation ();
		void StopUpdatingLocation ();
		event EventHandler<CLRegionEventArgs> RegionEntered;
		event EventHandler<CLRegionEventArgs> RegionLeft;
		event EventHandler<CLLocationsUpdatedEventArgs> LocationsUpdated;
		double DesiredAccuracy { get; set; }
	}
}

