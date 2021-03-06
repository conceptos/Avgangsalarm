using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services.Impl;
using System.Collections.Generic;
using System.Linq;
using Avgangsalarm.Core.Tests.Fakes;

namespace Avgangsalarm.Core.Tests.ServiceTests
{
	[TestFixture ()]
	public class UpdateEngineTests
	{
		private UpdateEngine _sut;

		private Region _region;

		private GetTrafikkDataFake _updateTrafikkDataFake;
		private MonitorGeoFencesFake _monitorGeoFencesFake;
		private PublishUpdatesFake[] _publishUpdatesFakeList;

		[SetUp]
		public void Setup()
		{
			var repositoryFake = new LocationRepositoryFake ();
			_monitorGeoFencesFake = new MonitorGeoFencesFake ();
			_updateTrafikkDataFake = new GetTrafikkDataFake ();
			_publishUpdatesFakeList = new [] { new PublishUpdatesFake () };

			_sut = 	new UpdateEngine (repositoryFake, _monitorGeoFencesFake, _updateTrafikkDataFake, _publishUpdatesFakeList);

			_region = new Region (123, 1, 2, 3);
			var locations = new List<Location> 
			{
				new Location("id", "name", _region, new Line[0])
			};

			repositoryFake.SetLoctions (locations);
		}

		[Test]
		public void MustNotAddRegionsBeforeStart ()
		{
			var isAdded = _monitorGeoFencesFake.AddedRegions.Contains (_region);
			var isRemoved = _monitorGeoFencesFake.RemovedRegions.Contains (_region);

			Assert.IsFalse (isAdded);
			Assert.IsFalse (isRemoved);
		}

		[Test]
		public void MustAddRegionToWatchlistOnStart ()
		{
			_sut.Start ();
	
			var isAdded = _monitorGeoFencesFake.AddedRegions.Contains (_region);
			var isRemoved = _monitorGeoFencesFake.RemovedRegions.Contains (_region);

			Assert.IsTrue (isAdded);
			Assert.IsFalse (isRemoved);
		}

		[Test]
		public void MustRemoveRegionFromWatchlistOnStop ()
		{
			_sut.Start ();
			_sut.Stop ();

			var isAdded = _monitorGeoFencesFake.AddedRegions.Contains (_region);
			var isRemoved = _monitorGeoFencesFake.RemovedRegions.Contains (_region);

			Assert.IsTrue (isAdded);
			Assert.IsTrue (isRemoved);
		}

		[Test]
		public void MustFetchTrafikkDataOnEnterRegion()
		{
			_monitorGeoFencesFake.TriggerEnterered (_region);
			Assert.IsTrue (_updateTrafikkDataFake.GetDeparturesForStopWasCalledForRegion(_region.StopId));
		}

		[Test]
		public void MustPublishReceivedUpdates()
		{
			_monitorGeoFencesFake.TriggerEnterered (_region);
			var hasPublishedDepartures = _publishUpdatesFakeList.Single ().UpdatedDepartures.Any ();
			Assert.IsTrue (hasPublishedDepartures);
		}
	}
}

