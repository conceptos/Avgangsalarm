using System;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;

namespace Avgangsalarm.Core.Services
{
	public interface IPublishUpdates
	{
		void NotifyUpdatedDepartures(IEnumerable<Departure> departure);
		event EventHandler<IEnumerable<Departure>> DeparturesUpdated;
	}
}

