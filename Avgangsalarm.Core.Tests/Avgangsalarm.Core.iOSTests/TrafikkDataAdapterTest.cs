using System;
using NUnit.Framework;
using System.Linq;
using Avgangsalarm.iOS.ServiceImpl;

namespace Avgangsalarm.Core.iOSTests
{
	[TestFixture]
	public class TrafikkDataAdapterTest
	{
		TrafikkDatAdapter _sut;
		private const int CarlBernersPlassStopId = 3011400;

		[SetUp]
		public void Setup()
		{
			_sut = new TrafikkDatAdapter (new TrafikkDataDeserializer());
		}

		[Test]
		public void KanHenteData()
		{
			var result = _sut.GetLineDeparturesForStopId (CarlBernersPlassStopId).Result;
			Assert.IsTrue (result.Any());
		}
	}
}

