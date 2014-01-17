using System;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core.Services.Impl;

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

