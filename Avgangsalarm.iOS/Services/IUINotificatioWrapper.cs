using System;
using MonoTouch.UIKit;

namespace Avgangsalarm.iOS
{
	public interface IUINotificationWrapper
	{
		void ScheduleNotification();
		string AlertAction { get; set; }
		string AlertBody { get; set; }
		DateTime FireDate { get;set; }
	}

}

