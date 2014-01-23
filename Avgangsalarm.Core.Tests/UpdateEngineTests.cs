using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services.Impl;

namespace Avgangsalarm.Core.Tests
{
	[TestFixture ()]
	public class UpdateEngineTests
	{
		private UpdateEngine _sut;

		[SetUp]
		public void Setup()
		{
			_sut = new UpdateEngine ();
		}

		[Test]
		public void MustAddRegionToWatchlistWhenEntered ()
		{
			Assert.Fail ();
		}

		[Test]
		public void MustRemoveRegionFromWatchlistWhenLeft ()
		{
			Assert.Fail ();
		}
	}
}

