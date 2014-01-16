using System;
using NUnit.Framework;
using Avgangsalarm.Core.iOS;
using System.Linq;

namespace Avgangsalarm.iOS.Tests.IntegrationTests
{
	[TestFixture]
	public class TrafikkDataTests
	{
		TrafikkDataService _sut;
		private const int CarlBernersPlassStopId = 3011400;

		[SetUp]
		public void Setup()
		{
			_sut = new TrafikkDataService ();
		}

		[Test]
		public void KanHenteData()
		{

			var result = _sut.GetLineDeparturesForStopId (CarlBernersPlassStopId).Result;
			Assert.IsTrue (result.Any());
		}
	}
}
