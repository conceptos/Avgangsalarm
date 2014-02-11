using System;
using MonoTouch.UIKit;

namespace Avgangsalarm.iOS.Services.Impl
{
	public class AppStateGateway : IAppStateGateway
	{
		#region IAppStateService implementation

		public UIApplicationState ApplicationState 
		{
			get 
			{
				return UIApplication.SharedApplication.ApplicationState;
			}
		}

		#endregion
	}

}

