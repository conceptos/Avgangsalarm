using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services;

namespace Avgangsalarm.Core.Tests.ServiceTests
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