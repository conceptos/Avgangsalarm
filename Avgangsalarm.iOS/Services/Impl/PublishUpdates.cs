using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using MonoTouch.UIKit;
using System.Text;

namespace Avgangsalarm.iOS.Services.Impl
{
	public class PublishUpdates : IPublishUpdates
	{
		readonly IAppStateGateway _appStateGateway;
		IUINotificationWrapper _notificationWrapper;

		public PublishUpdates(IAppStateGateway appStateGateway)
		{
			_appStateGateway = appStateGateway;
		}

		#region IPublishUpdates implementation

		public void NotifyUpdatedDepartures (IEnumerable<Departure> departures)
		{
			UpdateMessage (departures); 

			DeparturesUpdated.Invoke (this, departures);
		}
			
		public event EventHandler<IEnumerable<Departure>> DeparturesUpdated = delegate {};

		private string CreateMessage (IEnumerable<Departure> departures)
		{
			var sb = new StringBuilder ();

			foreach (var departure in departures) 
			{
				sb.AppendLine (string.Format ("{0} {1}", 
					departure.Line, 
					departure.DepartureTime.ToShortTimeString ()));
			}

			return sb.ToString ();
		}
			
		void UpdateMessage (IEnumerable<Departure> departures)
		{
			if (_appStateGateway.ApplicationState == UIApplicationState.Background) {
				NotificationWrapper.AlertAction = "View Alert";
				NotificationWrapper.AlertBody = CreateMessage (departures);
				NotificationWrapper.FireDate = DateTime.Now;
				NotificationWrapper.ScheduleNotification ();
			}
		}
		#endregion

		public IUINotificationWrapper NotificationWrapper 
		{
			get 
			{
				if (_notificationWrapper == null) 
				{
					_notificationWrapper = new UINotificationWrapper ();
				}
				return _notificationWrapper;
			}
			set 
			{
				_notificationWrapper = value;
			}
		}

	}
}

