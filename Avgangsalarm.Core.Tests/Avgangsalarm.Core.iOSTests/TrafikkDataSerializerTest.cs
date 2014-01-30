using System;
using NUnit.Framework;
using Avgangsalarm.iOS.ServiceImpl;
using System.Linq;

namespace Avgangsalarm.Core.iOSTests
{
	[TestFixture]
	public class TrafikkDataSerializerTest
	{
		TrafikkDataDeserializer _serializer;

		private const string JsonResult = "[{\"AimedArrivalTime\":\"\\/Date(1391081100000+0100)\\/\"," + 
		                                  "\"AimedDepartureTime\":\"\\/Date(1391081100000+0100)\\/\"," + 
		                                  "\"ArrivalBoardingActivity\":null,"+
		                                  "\"BlockRef\":\"524:4H01H02\","+
		                                  "\"Delay\":\"PT137S\","+
		                                  "\"DepartureBoardingActivity\":null,"+
		                                  "\"DeparturePlatformName\":\"1\","+
		                                  "\"DestinationDisplay\":\"Vestli\","+
		                                  "\"DestinationName\":\"Vestli\","+
		                                  "\"DestinationRef\":3011730,"+
		                                  "\"DirectionName\":\"1\","+
		                                  "\"DirectionRef\":\"1\","+
		                                  "\"ExpectedArrivalTime\":\"\\/Date(1391081237000+0100)\\/\","+
		                                  "\"ExpectedDepartureTime\":\"\\/Date(1391081237000+0100)\\/\","+
		                                  "\"Extensions\":"+
		                                  "{\"Deviations\":[],"+
		                                  "\"OccupancyData\":null"+
		                                  "},"+
		                                  "\"FramedVehicleJourneyRef\":"+
		                                  "{\"DataFrameRef\":\"2014-01-30\","+
		                                  "\"DatedVehicleJourneyRef\":\"3595\"},"+
		                                  "\"LineRef\":\"5\","+
		                                  "\"InCongestion\":true,"+
		                                  "\"Monitored\":true,"+
		                                  "\"OperatorRef\":\"me\","+
		                                  "\"OriginName\":\"ØSÅ1\","+
		                                  "\"OriginRef\":\"2190090\","+
		                                  "\"PublishedLineName\":\"5\","+
		                                  "\"StopVisitNote\":null,"+
		                                  "\"TrainBlockPart\":"+
		                                  "{\"NumberOfBlockParts\":6"+
		                                  "},"+
		                                  "\"VehicleAtStop\":false,"+
		                                  "\"VehicleFeatureRef\":\"\","+
		                                  "\"VehicleJourneyName\":\"\","+
		                                  "\"VehicleMode\":4,"+
		                                  "\"VehicleRef\":\"209\","+
		                                  "\"ViaName1\":null,"+
		                                  "\"VisitNumber\":20}]";
	
		LineDeparture _result;

		[SetUp]
		public void Setup()
		{
			_serializer = new TrafikkDataDeserializer ();
			var results = _serializer.DeserializeLineDepartures (JsonResult);
			_result = results.Single ();
		}

		[Test]
		public void CanMap_PublishedLineName()
		{
			Assert.AreEqual ("5", _result.PublishedLineName);
		}

		[Test]
		public void CanMap_LineRef()
		{
			Assert.AreEqual (5, _result.LineRef);
		}

		[Test]
		public void CanMap_DestinationName()
		{
			Assert.AreEqual ("Vestli", _result.DestinationName);
		}

	
		[Test]
		public void CanMap_DestinationDateTime()
		{
			Assert.AreEqual ("/Date(1391081237000+0100)/", _result.ExpectedDepartureTime);
		}

		[Test]
		public void CanMap_DeparturePlatformName()
		{
			Assert.AreEqual ("1", _result.DeparturePlatformName);
		}

		[Test]
		public void CanMap_DestinationDisplay()
		{
			Assert.AreEqual ("Vestli", _result.DestinationDisplay);
		}

		[Test]
		public void CanMap_Incongestion()
		{
			Assert.IsTrue (_result.InCongestion);
		}	

		[Test]
		public void CanMap_VehicleMode()
		{
			Assert.AreEqual (4, _result.VehicleMode);
		}
			
	}	
}

