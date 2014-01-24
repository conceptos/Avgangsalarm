using System;
using Avgangsalarm.Core.Services;

namespace Avgangsalarm.iOS
{
	// http://docs.xamarin.com/guides/cross-platform/application_fundamentals/backgrounding/part_3_ios_backgrounding_techniques/updating_an_application_in_the_background/#remote_notifications
	public class UpdateNotificationScreen : IPublishUpdates
	{
		#region IPublishUpdates implementation

		public void NotifyUpdatedDepartures (System.Collections.Generic.IEnumerable<Avgangsalarm.Core.Models.Departure> departure)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

