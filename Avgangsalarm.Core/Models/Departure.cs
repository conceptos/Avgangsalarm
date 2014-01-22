using System;

namespace Avgangsalarm.Core.Models
{
	public class Departure
	{
		public Departure (Line line, DateTime departure)
		{
			Line = line;
			DepartureTime = departure;
		}

		public Line Line { get; private set; }
		public DateTime DepartureTime { get; set; }
	}
}

