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
		bool _regionEntered;
		bool _regionLeft;

		[SetUp]
		public void Setup ()
		{
			SetupLocationManagerWrapperFake ();
			_sut = new MonitorGeoFences (_fake);

			_sut.RegionEntered += (o, e) =>  {
				_regionEntered = true;
			};
			_sut.RegionLeft += (o, e) =>  {
				_regionLeft = true;
			};

			_region = new Region (123, 0, 1, 2);
		}

		[Test]
		public void RegionNotAddedByDefault()
		{
			Assert.IsFalse (_sut.GetRegions ().Any ());
			Assert.IsFalse (_fake.MonitoredRegionsAdded.Any());
		}	

		[Test]
		public void CanAddMultipleRegions()
		{
			_sut.AddRegion (_region);
			_sut.AddRegion (new Region(123, 1, 2, 3));

			Assert.AreEqual ("MonitorRegion_1", _fake.MonitoredRegionsAdded.First());
			Assert.AreEqual ("MonitorRegion_2", _fake.MonitoredRegionsAdded.Last());		
		}	

		[Test]
		public void CanAddRegion()
		{
			_sut.AddRegion (_region);	

			var containsRegion = ContainsRegion ();
			var monitoredRegion = _fake.MonitoredRegionsAdded.Single ();

			Assert.AreEqual ("MonitorRegion_1", monitoredRegion);
			Assert.IsTrue (containsRegion);
		}

		[Test]
		public void CanRemoveRegion()
		{
			_sut.AddRegion (_region);	
			_sut.RemoveRegion (_region);

			var containsRegion = ContainsRegion ();
			var removedRegion = _fake.MonitoredRegionsRemoved.Single ();

			Assert.IsFalse (containsRegion);
			Assert.AreEqual ("MonitorRegion_1", removedRegion);
		}
			
		[Test]
		public void IsNotNotifiedWhenNotRegionEntered()
		{
			_sut.AddRegion (_region);	
			Assert.IsFalse (_regionEntered);
		}

		[Test]
		public void IsNotNotifiedWhenRegionNotLeft()
		{
			_sut.AddRegion (_region);	
			Assert.IsFalse (_regionLeft);
		}

		[Test]
		public void IsNotifiedWhenRegionEntered()
		{
			_sut.AddRegion (_region);
			_fake.TriggerRegionEntered (_region, "MonitorRegion_1");
			Assert.IsTrue (_regionEntered);
		}

		[Test]
		public void IsNotifiedWhenRegionLeft()
		{
			_sut.AddRegion (_region);	
			_fake.TriggerRegionLeft (_region, "MonitorRegion_1");
			Assert.IsTrue (_regionLeft);
		}

		[Test]
		public void IsNotNotifiedWhenUnknownRegionEntered()
		{
			_sut.AddRegion (_region);
			_fake.TriggerRegionEntered (_region, "Unknown");
			Assert.IsFalse (_regionEntered);
		}

		[Test]
		public void IsNotNotifiedWhenRegionLeft()
		{
			_sut.AddRegion (_region);	
			_fake.TriggerRegionLeft (_region, "Unknown");
			Assert.IsFalse (_regionLeft);
		}

		void SetupLocationManagerWrapperFake ()
		{
			_fake = new CLLocationManagerWrapperFake ();
			_regionEntered = false;
			_regionLeft = false;
		}
	
		bool ContainsRegion ()
		{
			return _sut.GetRegions ().Contains (_region);
		}
	}
}

