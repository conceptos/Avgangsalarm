using System;
using System.Collections.Generic;

namespace Avgangsalarm.Core.Services
{
	public interface ILocationRepository
	{
		void Add(Location location);
		void Delete(Location location);
		void Save();

		IEnumerable<Location> FetchAll();
	}
}

