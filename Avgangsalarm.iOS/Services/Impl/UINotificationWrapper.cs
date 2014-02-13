using System;
using MonoTouch.UIKit;

namespace Avgangsalarm.iOS.Services.Impl
{
	public class UINotificationWrapper : IUINotificationWrapper
	{
		UILocalNotification _localNotification;

		public UINotificationWrapper() 
			: this(new UILocalNotification()) {}

		public UINotificationWrapper(UILocalNotification localNotification)
		{
			_localNotification = localNotification;
		}

		public string AlertAction 
		{
			get 
			{
				return _localNotification.AlertAction;
			}
			set 
			{
				_localNotification.AlertAction = value;
			}
		}

		public string AlertBody 
		{
			get 
			{
				return _localNotification.AlertBody;
			}
			set 
			{
				_localNotification.AlertBody = value;
			}
		}

		public System.DateTime FireDate 
		{
			get 
			{
				return _localNotification.FireDate;
			}
			set 
			{
				_localNotification.FireDate = value;
			}
		}

		public void ScheduleNotification()
		{
			UIApplication.SharedApplication.ScheduleLocalNotification (_localNotification);
		}
	}
}
