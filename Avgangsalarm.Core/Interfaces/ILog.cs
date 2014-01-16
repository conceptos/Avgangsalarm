using System;

namespace Avgangsalarm.Core
{
	public interface ILog
	{
		void Info(string format, params object[] args);

		void Warn(string format, params object[] args);

		void Error(Exception exception);
	}
}

