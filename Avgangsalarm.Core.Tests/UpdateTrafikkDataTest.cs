using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services.Impl;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.Tests
{
	[TestFixture ()]
	public class UpdateTrafikkDataTest
	{
		UpdateTrafikkData _sut;

		[SetUp]
		public void Setup() 
		{
			_sut = new UpdateTrafikkData(new FakeTrafikkDataAdapter());
		}

		[Test ()]
		public void ReturnsUpdatedLines ()
		{
			var relevant = new List<Line> 
			{
				new Line("31", "Gokk!")
		 	};
			var departures = _sut.GetDeparturesForStop (1234, relevant);
			Assert.AreEqual ("31", departures.Single ().Line.Id);
		}

		[Test ()]
		public void ReturnsCorrectDateTimes()
		{
			var relevant = new List<Line> 
			{
				new Line("31", "Gokk!")
			};
			var departures = _sut.GetDeparturesForStop (1234, relevant);
			var departureTime = departures.Single ().DepartureTime;
			Assert.AreEqual (new DateTime(2014, 01, 22, 12, 29, 13), departureTime);
		}

		[Test ()]
		public void DoesNotUpdateIrrelevantLines ()
		{
			var relevant = new List<Line> 
			{
				new Line("500", "Gokk!")
			};
			var departures = _sut.GetDeparturesForStop (1234, relevant);
			Assert.IsFalse (departures.Any ());
		}
	}

}

