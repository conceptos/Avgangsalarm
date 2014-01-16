using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Avgangsalarm.Core
{
	public interface ITrafikkDataService
	{
		Task<IEnumerable<LineDeparture>> GetLineDeparturesForStopId(int stopId);
	}
}

