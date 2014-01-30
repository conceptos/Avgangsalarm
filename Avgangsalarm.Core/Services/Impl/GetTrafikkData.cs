using System;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.Services.Impl
{
	public class GetTrafikkData : IUpdateTrafikkdata
	{
		ITrafikkDataAdapter _trafikkDataAdapter;
		public GetTrafikkData (ITrafikkDataAdapter trafikkDataAdapter)
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
				var departure = CreateDeparture (stopId, ld);
				departures.Add (departure);
			}
			return departures;
		}

		#endregion

		private static Departure CreateDeparture (int stopId, LineDeparture ld)
		{
			var line = new Line (ld.LineRef.ToString(), ld.DestinationName);
			var departureTime = ld.ExpectedDepartureTime.ConvertToDate ();
			var transportationType = (TransportationType)ld.VehicleMode;
			var departure = new Departure (stopId, line, departureTime, transportationType);
			return departure;
		}
	}
}

