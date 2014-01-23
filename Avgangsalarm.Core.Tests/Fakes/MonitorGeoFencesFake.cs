using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace Avgangsalarm.Core.Tests.Fakes
{
	public class MonitorGeoFencesFake : IMonitorGeoFences
	{
		public IEnumerable<Region> AddedRegions { get; private set; }
		public IEnumerable<Region> RemovedRegions { get; private set; }

		public MonitorGeoFencesFake()
		{
			AddedRegions = new List<Region> ();
			RemovedRegions = new List<Region> ();		
		}

		#region IMonitorGeoFences implementation

		public event EventHandler<Region> RegionEntered;
		public event EventHandler<Region> RegionLeft;
		public event EventHandler<object> NativeLocationUpdatedEvent;

		public void AddRegion (Region region)
		{
			((List<Region>)AddedRegions).Add (region);
		}

		public void RemoveRegion (Region region)
		{
			((List<Region>)RemovedRegions).Add (region);
		}

		public IEnumerable<Region> GetRegions ()
		{
			var regions = new List<Region> (AddedRegions);
			return regions.Except (RemovedRegions);
		}

		#endregion
	}
}

