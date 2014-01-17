using System;
using System.Diagnostics;

namespace Avgangsalarm.Core.Services.Impl
{
	class DebugLogger : ILog
   	{
		#region Helper Methods
		private string CreateLogMessage(string format, params object[] args)
		{
			return string.Format("[{0}] {1}", 
                    DateTime.Now.ToString("o"),
                    string.Format(format, args));
		}
		#endregion

		#region ILog Members
		public void Error(Exception exception)
		{
      		Debug.WriteLine(CreateLogMessage(exception.ToString()), "ERROR");
    	}
		public void Info(string format, params object[] args)
		{
      		Debug.WriteLine(CreateLogMessage(format, args), "INFO");
		}
		public void Warn(string format, params object[] args)
		{
      		Debug.WriteLine(CreateLogMessage(format, args), "WARN");
    	}
		#endregion
	}
}

