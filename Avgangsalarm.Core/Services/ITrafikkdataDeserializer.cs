using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.Services
{
	public interface ITrafikkdataDeserializer
	{
		IEnumerable<LineDeparture> DeserializeLineDepartures (string content);
	}
}

