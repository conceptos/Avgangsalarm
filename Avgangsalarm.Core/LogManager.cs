using System;

namespace Avgangsalarm.Core
{
	public static class LogManager
	{
		private static ILog _ilog = new DebugLogger();


		public static ILog GetLogger(Type t)
		{
			return _ilog;
		}
	}
}

