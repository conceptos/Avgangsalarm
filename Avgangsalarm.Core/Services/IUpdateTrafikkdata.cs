using System;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.Services
{
	public interface IUpdateTrafikkdata
	{
		Task<IEnumerable<Departure>> GetDeparturesForStop(int stopId);
	}
}

