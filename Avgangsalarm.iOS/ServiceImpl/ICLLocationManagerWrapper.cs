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
		event EventHandler<CLRegionEventArgs> RegionEntered;
		event EventHandler<CLRegionEventArgs> RegionLeft;
		double DesiredAccuracy { get; set; }
	}
}

