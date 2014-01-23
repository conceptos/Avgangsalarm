using System;
using Avgangsalarm.Core.Services;

namespace Avgangsalarm.iOS
{
	// http://docs.xamarin.com/guides/cross-platform/application_fundamentals/backgrounding/part_3_ios_backgrounding_techniques/updating_an_application_in_the_background/#remote_notifications
	public class UpdateNotificationScreen : IUpdateNotificationScreen
	{
		#region IUpdateNotificationScreen implementation

		public void Notify (string message)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

