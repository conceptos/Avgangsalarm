using System;

namespace Avgangsalarm.Core
{
	public class LineDeparture
	{
		// TODO: Lære seg nok SimpleJSON til å kunne konvertere tall
		public string PublishedLineName { get; set; }
		public string LineRef { get; set; }
		//public int LineRef { get; set; }
		public string OperatorRef { get; set; }
		public string DestinationName { get; set; }
		public bool Monitored { get; set; }
		public string AimedArrivalTime { get; set; }
		//public DateTime AimedArrivalTime { get; set; }
		public string ExpectedArrivalTime { get; set; }
		//public DateTime ExpectedArrivalTime { get; set; }
		public string AimedDepartureTime { get; set; }
		//public DateTime AimedDepartureTime { get; set; }
		public string ExpectedDepartureTime { get; set; }
		//public DateTime ExpectedDepartureTime { get; set; }
		public string DeparturePlatformName { get; set; }
		public string BlockRef { get; set; }
		public string DestinationDisplay { get; set; }
		public string VehicleRef { get; set; }
		public bool InCongestion { get; set; }
		public string DestinationRef { get; set; }
		// public int DestinationRef { get; set; }
		public string StopVisitNote { get; set; }
		public FramedVehicleJourneyRef FramedVehicleJourneyRef { get; set; }
		public TrainBlockPart  TrainBlockPart { get; set; }
		public string VehicleMode { get; set; }                   
		//public int? VehicleMode { get; set; }                   
		public VehicleFeatureRef VehicleFeatureRef { get; set; }
		public string ArrivalBoardingActivity { get; set; }       
		//public int? ArrivalBoardingActivity { get; set; }       
		public string DepartureBoardingActivity { get; set; }     
		//public int? DepartureBoardingActivity { get; set; }     
	}
}