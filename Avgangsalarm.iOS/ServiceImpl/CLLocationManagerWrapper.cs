using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using System.Collections.Generic;
using MonoTouch.CoreLocation;
using System.Linq;

namespace Avgangsalarm.iOS
{
	public class CLLocationManagerWrapper : ICLLocationManagerWrapper
	{
		CLLocationManager _clLocationManager;
		public CLLocationManagerWrapper()
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
		}

		#region ICLLocationManagerWrapper implementation

		public event EventHandler<CLRegionEventArgs> RegionEntered = delegate {};
		public event EventHandler<CLRegionEventArgs> RegionLeft = delegate {};

		public double DesiredAccuracy 
		{
			get { return _clLocationManager.DesiredAccuracy; }
			set { _clLocationManager.DesiredAccuracy = value; }
		}

		#endregion


	}
}

