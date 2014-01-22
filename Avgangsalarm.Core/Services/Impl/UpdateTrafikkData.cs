using System;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using System.Linq;

namespace Avgangsalarm.Core.Services.Impl
{
	public class UpdateTrafikkData : IUpdateTrafikkdata
	{
		ITrafikkDataAdapter _trafikkDataAdapter;
		public UpdateTrafikkData (ITrafikkDataAdapter trafikkDataAdapter)
		{
			_trafikkDataAdapter = trafikkDataAdapter;
		}

		#region IUpdateTrafikkdata implementation

		public IEnumerable<Departure> GetDeparturesForStop (int stopId, IEnumerable<Line> lines)
		{
			var departures = new List<Departure> ();

			var lineDepartures = _trafikkDataAdapter.GetLineDeparturesForStopId (stopId).Result;
			foreach (LineDeparture ld in lineDepartures) 
			{
				var line = lines.FirstOrDefault (i => i.Id == ld.LineRef);
				if (line != null) 
				{
					var departure = new Departure(line, ld.ExpectedDepartureTime.ConvertToDate());
					departures.Add (departure);
				}
			}
			return departures;
		}

		#endregion
	}
}

