using System;

namespace Avgangsalarm.Core
{
	public class LineDeparture
	{
		public string PublishedLineName { get; set; }
		public string LineRef { get; set; }
		//public string OperatorRef { get; set; }
		public string DestinationName { get; set; }
		//public bool Monitored { get; set; }
		//public string AimedArrivalTime { get; set; }
		//public string ExpectedArrivalTime { get; set; }
		//public string AimedDepartureTime { get; set; }
		public string ExpectedDepartureTime { get; set; }
		public string DeparturePlatformName { get; set; }
		//public string BlockRef { get; set; }
		public string DestinationDisplay { get; set; }
		//public string VehicleRef { get; set; }
		public bool InCongestion { get; set; }
		//public string DestinationRef { get; set; }
		//public string StopVisitNote { get; set; }
		//public FramedVehicleJourneyRef FramedVehicleJourneyRef { get; set; }
		//public TrainBlockPart  TrainBlockPart { get; set; }
		public string VehicleMode { get; set; }                   
		//public VehicleFeatureRef VehicleFeatureRef { get; set; }
		//public string ArrivalBoardingActivity { get; set; }       
		//public string DepartureBoardingActivity { get; set; }     
	}
}