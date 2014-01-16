using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.iOS
{
	// TODO: Kan flyttes til core dersom vi velger å benytte Microsoft.Net.Http via NuGet
	public class TrafikkDataService : ITrafikkDataService
	{
		#region ITrafikkDataService implementation

		private const string GetStoppUri = "http://reis.trafikanten.no/reisrest/realtime/getalldepartures/";

		public Task<IEnumerable<LineDeparture>> GetLineDeparturesForStopId (int stopId)
		{
			var client = CreateClient(GetStoppUri);
			var content = client.GetStringAsync(stopId.ToString()).Result;
			var result = SimpleJson.DeserializeObject<IEnumerable<LineDeparture>>(content);
			return Task.FromResult(result);
		}

		private static HttpClient CreateClient(string uri)
		{
			var client = new HttpClient
			{
				BaseAddress = new Uri(uri)
			};
			return client;
		}

		#endregion
	}
}

