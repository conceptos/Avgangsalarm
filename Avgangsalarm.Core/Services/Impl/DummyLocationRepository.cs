using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace Avgangsalarm.Core
{
	public class DummyLocationRepository : ILocationRepository
	{
		private List<Location> Locations { get; set;}

		public DummyLocationRepository ()
		{
			Locations = new List<Location> 
			{
				new Location(
					"LokasjonId", 
					"Min lokasjon (Carl Berner)", 
					new Region(59.9400f, 66.44460f, 300),
					new [] { new Line("31", "Tonsenhagen") })
			};
		}

		#region ILocationRepository implementation

		public void Add (Location location)
		{
			Locations.Add (location);
		}

		public void Delete (Location location)
		{
			Locations.Remove (location);
		}

		public void Save ()
		{
			// TODO
		}

		public IEnumerable<Location> FetchAll ()
		{
			return Locations.ToList ();
		}

		#endregion
	}
}
