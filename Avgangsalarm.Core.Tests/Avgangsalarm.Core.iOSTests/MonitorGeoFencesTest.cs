using System;
using NUnit.Framework;
using Avgangsalarm.iOS;
using System.Linq;

namespace Avgangsalarm.Core.iOSTests
{
	[TestFixture]
	public class MonitorGeoFencesTest
	{
		MonitorGeoFences _sut;
		Region _region;

		[SetUp]
		public void Setup ()
		{
			_sut = new MonitorGeoFences ();
			_region = new Region (0, 1, 2);

			_sut.AddRegion (_region, "region");
			_sut.RemoveRegion (_region);
		}

		[Test]
		public void CanAddRegion()
		{
			var containsRegion = ContainsRegion ();
			Assert.IsTrue (containsRegion);
		}

		[Test]
		public void CanRemoveRegion()
		{
			var containsRegion = ContainsRegion ();
			Assert.IsFalse (containsRegion);
		}

		bool ContainsRegion ()
		{
			return _sut.GetRegions ().Contains (_region);
		}

	}
}

