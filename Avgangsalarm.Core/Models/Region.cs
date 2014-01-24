using System;

namespace Avgangsalarm.Core
{
	public class Region
	{
		public Region(int stopId, float latitude, float longitude, int alertZoneRadiusInMeters)
		{
			StopId = stopId;
			Latitude = latitude;
			Longitude = longitude;
			AlertZoneRadiusInMeters = alertZoneRadiusInMeters;
		}

		public int StopId { get; private set; }
		public float Latitude { get; private set; }
		public float Longitude { get; private set; }
		public int AlertZoneRadiusInMeters { get; private set; }
	}
}
