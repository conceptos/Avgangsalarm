using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avgangsalarm.Core.Services;

namespace Avgangsalarm.Core
{
	public class TrafikkDataAdapter : ITrafikkDataAdapter
	{
		ITrafikkdataDeserializer _serializer;

		public TrafikkDataAdapter(ITrafikkdataDeserializer serializer)
		{
			_serializer = serializer;
		}

		#region ITrafikkDataService implementation

		private const string GetStoppUri = "http://reis.trafikanten.no/reisrest/realtime/getalldepartures/";

		public Task<IEnumerable<LineDeparture>> GetLineDeparturesForStopId (int stopId)
		{
			var client = CreateClient(GetStoppUri);
			var content = client.GetStringAsync(stopId.ToString()).Result;

			var result = _serializer.DeserializeLineDepartures (content);

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

