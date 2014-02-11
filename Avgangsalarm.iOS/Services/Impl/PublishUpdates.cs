using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using MonoTouch.UIKit;

namespace Avgangsalarm.iOS.Services.Impl
{
	public class PublishUpdates : IPublishUpdates
	{
		readonly IAppStateGateway _appStateGateway;

		public PublishUpdates (IAppStateGateway appStateGateway)
		{
			_appStateGateway = appStateGateway;
		}

		#region IPublishUpdates implementation

		public void NotifyUpdatedDepartures (IEnumerable<Departure> departure)
		{
			var message = "";

			if (_appStateGateway.ApplicationState == UIApplicationState.Background) 
			{
			} 

			else 
			{

			}

		}
			
		public event EventHandler<IEnumerable<Departure>> DeparturesUpdated = delegate {};

		#endregion
	}
}

