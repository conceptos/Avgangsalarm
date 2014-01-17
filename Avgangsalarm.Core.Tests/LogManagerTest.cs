using NUnit.Framework;
using System;

namespace Avgangsalarm.Core.Tests
{
	[TestFixture ()]
	public class LogManagerTest
	{
		[Test]
		public void CanGetDefaultLogger ()
		{
			var logger = LogManager.GetLogger (this.GetType());
			Assert.IsNotNull (logger as ILog);
		}
	}
}