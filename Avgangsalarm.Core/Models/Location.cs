using System;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using System.Linq;

namespace Avgangsalarm.Core
{
	public class Location
	{
		public Location (string id, string name, Region region, IEnumerable<Line> linesToCheck)
		{
			Id = id;
			Name = name;
			Region = region;
			LinesToCheck = new List<Line> (linesToCheck);
		}

		public string Id { get; private set; }
		public string Name { get; private set; }
		public Region Region { get; private set; }
		public IEnumerable<Line> LinesToCheck  { get; private set; }
		public IEnumerable<Departure> Departures { get; private set; }

		public void UpdateDepartures (IEnumerable<Departure> departuresForStop)
		{
			var relevantDepartures = departuresForStop.Where (i => LinesToCheck.Contains (i.Line));
			Departures = relevantDepartures.ToList ();
		}
	}
}

