using System;
using MonoTouch.UIKit;

namespace Avgangsalarm.iOS.Services
{
	public interface IAppStateGateway 
	{
		UIApplicationState ApplicationState { get; }
	}
}
