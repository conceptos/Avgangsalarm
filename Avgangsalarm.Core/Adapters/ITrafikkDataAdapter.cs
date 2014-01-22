using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Avgangsalarm.Core
{
	public interface ITrafikkDataAdapter
	{
		Task<IEnumerable<LineDeparture>> GetLineDeparturesForStopId(int stopId);
	}
}

