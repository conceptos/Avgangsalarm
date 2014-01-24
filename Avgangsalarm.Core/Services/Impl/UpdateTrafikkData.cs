using System;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using System.Linq;
using System.Threading.Tasks;

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

		public async Task<IEnumerable<Departure>> GetDeparturesForStop (int stopId)
		{
			var departures = new List<Departure> ();

			var lineDepartures = await _trafikkDataAdapter.GetLineDeparturesForStopId (stopId);
			foreach (LineDeparture ld in lineDepartures) 
			{
				var line = new Line (ld.LineRef, ld.PublishedLineName);
				var departure = new Departure(line, ld.ExpectedDepartureTime.ConvertToDate());
				departures.Add (departure);
			}
			return departures;
		}

		#endregion
	}
}

