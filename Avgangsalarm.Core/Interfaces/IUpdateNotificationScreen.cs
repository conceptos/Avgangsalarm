using System;

namespace Avgangsalarm.Core
{
	public interface IUpdateNotificationScreen
	{
		void Error();
		void Information();
		void Debug();
	}
}

