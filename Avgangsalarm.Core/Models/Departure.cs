using System;

namespace Avgangsalarm.Core.Models
{
	public class Departure
	{
		public Departure (int stopId, Line line, DateTime departure, TransportationType transportationType)
		{
			StopId = stopId;
			Line = line;
			DepartureTime = departure;
		}

		public int StopId { get; private set; }
		public Line Line { get; private set; }
		public DateTime DepartureTime { get; set; }
		public TransportationType TransportationType { get; set; } 
	}
}

