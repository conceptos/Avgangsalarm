using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using Avgangsalarm.Core;
using System.Json;

namespace Avgangsalarm.iOS.ServiceImpl
{
	public class TrafikkDataDeserializer : ITrafikkdataDeserializer
	{
		#region ITrafikkdataDeserializer implementation

		public IEnumerable<LineDeparture> DeserializeLineDepartures (string content)
		{
			var array = JsonArray.Parse (content);
			var departures = new List<LineDeparture> ();

			foreach (JsonObject item in array) 
			{
				var departure = new LineDeparture ();
				departure.PublishedLineName = item["PublishedLineName"];
				departure.LineRef = item ["LineRef"];
				departure.ExpectedDepartureTime = item ["ExpectedDepartureTime"];
				departure.DeparturePlatformName = item ["DeparturePlatformName"];
				departure.DestinationDisplay = item ["DestinationDisplay"];
				departure.InCongestion = item ["InCongestion"];

				departures.Add (departure);
			}

			return departures;
		}

		#endregion	
	}
}

