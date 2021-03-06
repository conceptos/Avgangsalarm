using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services.Impl;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.Tests.ServiceTests
{
	[TestFixture ()]
	public class UpdateTrafikkDataTest
	{
		GetTrafikkData _sut;

		[SetUp]
		public void Setup() 
		{
			_sut = new GetTrafikkData(new TrafikkDataAdapterFake());
		}

		[Test ()]
		public void ReturnsUpdatedLines ()
		{
			var departures = _sut.GetDeparturesForStop (1234).Result;
			Assert.AreEqual ("31", departures.Single ().Line.Id);
		}

		[Test ()]
		public void ReturnsCorrectDateTimes()
		{
			var departures = _sut.GetDeparturesForStop (1234).Result;
			var departureTime = departures.Single ().DepartureTime;
			Assert.AreEqual (new DateTime(2014, 01, 22, 12, 29, 13), departureTime);
		}
	}

}

