using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;

namespace Avgangsalarm.iOS.Services.Impl
{
	// http://docs.xamarin.com/guides/cross-platform/application_fundamentals/backgrounding/part_3_ios_backgrounding_techniques/updating_an_application_in_the_background/#remote_notifications
	public class UpdateNotificationScreen : IPublishUpdates
	{
		#region IPublishUpdates implementation

		public void NotifyUpdatedDepartures (IEnumerable<Departure> departure)
		{
			throw new NotImplementedException ();
		}

		public event EventHandler<IEnumerable<Departure>> DeparturesUpdated;
		#endregion
	}
}

