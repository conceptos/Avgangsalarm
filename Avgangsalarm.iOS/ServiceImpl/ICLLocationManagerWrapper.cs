using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using System.Collections.Generic;
using MonoTouch.CoreLocation;
using System.Linq;

namespace Avgangsalarm.iOS
{
	public interface ICLLocationManagerWrapper
	{
		void StartMonitoring (CLRegion clCircularRegion);
		void StopMonitoring (CLRegion clCircularRegion);
		event EventHandler<CLRegionEventArgs> RegionEntered;
		event EventHandler<CLRegionEventArgs> RegionLeft;
		event EventHandler<CLLocationsUpdatedEventArgs> LocationsUpdated;
		double DesiredAccuracy { get; set; }
	}
}

