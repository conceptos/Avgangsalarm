using System;
using System.Collections.Generic;

namespace Avgangsalarm.Core
{
	public class Line
	{
		public Line(string id, string destination)
		{
			Id = id;
			Destination = destination;
		}
		public string Id { get; private set; }
		public string Destination { get; set; }
	}
}

