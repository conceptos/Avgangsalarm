using System;
using System.Collections.Generic;

namespace Avgangsalarm.Core
{
	public interface ILocationRepository
	{
		void Add(Location location);
		void Delete(Location location);
		void Save();

		IEnumerable<Location> FetchAll();
	}
}

