using System;
using System.Collections.Generic;

namespace Avgangsalarm.Core.Services
{
	public interface IMonitorGeoFences
	{
		void AddRegion (Region region, string name);
		void RemoveRegion (Region region);
		IEnumerable<Region> GetRegions ();

		event EventHandler<Region> RegionEntered;
		event EventHandler<Region> RegionLeft;
	}
}

