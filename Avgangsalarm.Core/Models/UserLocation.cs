using System;

namespace Avgangsalarm.Core
{
	public class UserLocation
	{
		public UserLocation (double latitude, double longitude, double accuracy)
		{
			Latitude = latitude;
			Longitude = longitude;
			Accuracy = accuracy;
		}

		public double Latitude { private get; set; }
		public double Longitude { private get; set; }
		public double Accuracy { private get; set; }
	}
}

