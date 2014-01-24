using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core.Models;
using System.Collections.Generic;

namespace Avgangsalarm.Core.Tests
{
	public class PublishUpdatesFake : IPublishUpdates
	{
		private List<Departure> _updatedDepartures;
		public IEnumerable<Departure> UpdatedDepartures { get { return _updatedDepartures; }}

		#region IPublishUpdates implementation
		public void NotifyUpdatedDepartures (IEnumerable<Departure> departure)
		{
			_updatedDepartures.AddRange (departure);
		}
		#endregion
	}
}

