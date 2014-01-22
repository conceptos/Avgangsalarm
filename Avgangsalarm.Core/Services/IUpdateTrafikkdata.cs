using System;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;

namespace Avgangsalarm.Core.Services
{
	public interface IUpdateTrafikkdata
	{
		IEnumerable<Departure> GetDeparturesForStop(int stopId, IEnumerable<Line> lines);
	}
}

