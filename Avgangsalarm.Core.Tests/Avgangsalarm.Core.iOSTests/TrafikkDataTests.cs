using System;
using NUnit.Framework;
using System.Linq;

namespace Avgangsalarm.Core.iOSTests
{
	[TestFixture]
	public class TrafikkDataTests
	{
		TrafikkDatAdapter _sut;
		private const int CarlBernersPlassStopId = 3011400;

		[SetUp]
		public void Setup()
		{
			_sut = new TrafikkDatAdapter ();
		}

		[Test]
		public void KanHenteData()
		{
			var result = _sut.GetLineDeparturesForStopId (CarlBernersPlassStopId).Result;
			Assert.IsTrue (result.Any());
		}
	}
}

