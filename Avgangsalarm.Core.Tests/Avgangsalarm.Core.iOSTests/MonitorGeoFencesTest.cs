using System;
using NUnit.Framework;
using Avgangsalarm.iOS;
using System.Linq;
using MonoTouch.CoreLocation;
using Avgangsalarm.Core.iOSTests.Fakes;

namespace Avgangsalarm.Core.iOSTests
{
	[TestFixture]
	public class MonitorGeoFencesTest
	{
		MonitorGeoFences _sut;

		Region _region;
		CLLocationManagerWrapperFake _fake;
		bool _regionEntered = false;
		bool _regionLeft = false;

		[SetUp]
		public void Setup ()
		{
			_fake = new CLLocationManagerWrapperFake ();
			_sut = new MonitorGeoFences (_fake);

			_region = new Region (0, 1, 2);
			_sut.AddRegion (_region, "region");

			_sut.RegionEntered += (o, e) => 
			{ 
				_regionEntered = true;
			};

			_sut.RegionLeft += (o, e) => 
			{ 
				_regionLeft = true; 
			};
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
			_sut.RemoveRegion (_region);
			var containsRegion = ContainsRegion ();
			Assert.IsFalse (containsRegion);
		}

		[Test]
		public void IsNotNotifiedWhenNotRegionEntered()
		{
			Assert.IsFalse (_regionEntered);
		}

		[Test]
		public void IsNotNotifiedWhenRegionNotLeft()
		{
			Assert.IsFalse (_regionLeft);
		}

		[Test]
		public void IsNotifiedWhenRegionEntered()
		{
			_fake.TriggerRegionEntered ();
			Assert.IsTrue (_regionEntered);
		}

		[Test]
		public void IsNotifiedWhenRegionLeft()
		{
			_fake.TriggerRegionLeft ();
			Assert.IsTrue (_regionLeft);
		}
	
		bool ContainsRegion ()
		{
			return _sut.GetRegions ().Contains (_region);
		}


	}
}

